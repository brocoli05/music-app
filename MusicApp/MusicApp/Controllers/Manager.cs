using AutoMapper;
using MusicApp.Data;
using MusicApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MusicApp.Controllers
{
    public class Manager
    {
        // Reference to the data context
        private DataContext ds = new DataContext();

        // AutoMapper instance
        public IMapper mapper;

        public Manager()
        {
            // If necessary, add more constructor code here...

            // Configure the AutoMapper components
            var config = new MapperConfiguration(cfg =>
            {
                // Define the mappings below, for example...
                // cfg.CreateMap<SourceType, DestinationType>();
                // cfg.CreateMap<Product, ProductBaseViewModel>();
                cfg.CreateMap<Track, TrackBaseViewModel>();
                cfg.CreateMap<Track, TrackWithDetailViewModel>()
                        .ForMember(dest => dest.AlbumTitle, opt => opt.MapFrom(src => src.Album.Title))
                        .ForMember(dest => dest.GenreName, opt => opt.MapFrom(src => src.Genre.Name));

                cfg.CreateMap<Invoice, InvoiceBaseViewModel>();
                cfg.CreateMap<Invoice, InvoiceWithDetailViewModel>()
                        .ForMember(dest => dest.CustomerFirstName, opt => opt.MapFrom(src => src.Customer.FirstName))
                        .ForMember(dest => dest.CustomerLastName, opt => opt.MapFrom(src => src.Customer.LastName))
                        .ForMember(dest => dest.CustomerState, opt => opt.MapFrom(src => src.Customer.State))
                        .ForMember(dest => dest.CustomerCountry, opt => opt.MapFrom(src => src.Customer.Country))
                        .ForMember(dest => dest.CustomerEmployeeFirstName, opt => opt.MapFrom(src => src.Customer.Employee.FirstName))
                        .ForMember(dest => dest.CustomerEmployeeLastName, opt => opt.MapFrom(src => src.Customer.Employee.LastName));

                cfg.CreateMap<InvoiceLine, InvoiceLineBaseViewModel>();

                cfg.CreateMap<InvoiceLine, InvoiceLineWithDetailViewModel>();
                cfg.CreateMap<InvoiceLine, InvoiceLineWithDetailViewModel>()
                        .ForMember(dest => dest.TrackName, opt => opt.MapFrom(src => src.Track.Name))
                        .ForMember(dest => dest.TrackComposer, opt => opt.MapFrom(src => src.Track.Composer))
                        .ForMember(dest => dest.AlbumTitle, opt => opt.MapFrom(src => src.Track.Album.Title))
                        .ForMember(dest => dest.ArtistName, opt => opt.MapFrom(src => src.Track.Album.Artist.Name))
                        .ForMember(dest => dest.GenreName, opt => opt.MapFrom(src => src.Track.Genre.Name))
                        .ForMember(dest => dest.MediaTypeName, opt => opt.MapFrom(src => src.Track.MediaType.Name));

                cfg.CreateMap<Album, AlbumBaseViewModel>();
                cfg.CreateMap<Artist, ArtistBaseViewModel>();
                cfg.CreateMap<MediaType, MediaTypeBaseViewModel>();

                cfg.CreateMap<Track, TrackBaseViewModel>();
                cfg.CreateMap<Track, TrackWithDetailViewModel>();
                cfg.CreateMap<TrackWithDetailViewModel, Track>();
                cfg.CreateMap<TrackAddViewModel, Track>();
                cfg.CreateMap<TrackAddFormViewModel, TrackAddViewModel>();

                cfg.CreateMap<Playlist, PlaylistBaseViewModel>();
                cfg.CreateMap<Playlist, PlaylistWithTracksViewModel>();
                cfg.CreateMap<Playlist, PlaylistEditTracksViewModel>();
                cfg.CreateMap<PlaylistWithTracksViewModel, PlaylistEditTracksFormViewModel>();
            });

            mapper = config.CreateMapper();

            // Turn off the Entity Framework (EF) proxy creation features
            // We do NOT want the EF to track changes - we'll do that ourselves
            ds.Configuration.ProxyCreationEnabled = false;

            // Also, turn off lazy loading...
            // We want to retain control over fetching related objects
            ds.Configuration.LazyLoadingEnabled = false;
        }


        // Add your methods below and call them from controllers. Ensure that your methods accept
        // and deliver ONLY view model objects and collections. When working with collections, the
        // return type is almost always IEnumerable<T>.
        //
        // Remember to use the suggested naming convention, for example:
        // ProductGetAll(), ProductGetById(), ProductAdd(), ProductEdit(), and ProductDelete().

        // Invoice
        public IEnumerable<InvoiceWithDetailViewModel> InvoiceGetAll()
        {
            var invoices = ds.Invoices
                .OrderByDescending(i => i.InvoiceDate);

            return mapper.Map<IEnumerable<Invoice>, IEnumerable<InvoiceWithDetailViewModel>>(invoices);
        }

        public InvoiceWithDetailViewModel InvoiceGetByIdWithDetail(int id)
        {
            // Fetch the invoice with the associated customer and employee details
            var invoice = ds.Invoices
                .Include("Customer")
                .Include("Customer.Employee")
                .Include("InvoiceLines")
                .Include("InvoiceLines.Track")
                .Include("InvoiceLines.Track.Album")
                .Include("InvoiceLines.Track.Album.Artist")
                .Include("InvoiceLines.Track.Genre")
                .Include("InvoiceLines.Track.MediaType")
                .SingleOrDefault(i => i.InvoiceId == id);

            // Return null if invoice not found
            if (invoice == null)
            {
                return null;
            }

            // Map the Invoice entity to InvoiceWithDetailViewModel
            return mapper.Map<Invoice, InvoiceWithDetailViewModel>(invoice);
        }

        // Album – Sort the results by album title
        public IEnumerable<AlbumBaseViewModel> AlbumGetAll()
        {
            var albums = ds.Albums.OrderBy(a => a.Title);
            return mapper.Map<IEnumerable<Album>, IEnumerable<AlbumBaseViewModel>>(albums);
        }

        // Artist – Sort the results by artist name
        public IEnumerable<ArtistBaseViewModel> ArtistGetAll()
        {
            var artists = ds.Artists.OrderBy(a => a.Name);
            return mapper.Map<IEnumerable<Artist>, IEnumerable<ArtistBaseViewModel>>(artists);
        }

        // MediaType – Sort the results by media type name
        public IEnumerable<MediaTypeBaseViewModel> MediaTypeGetAll()
        {
            var mediaTypes = ds.MediaTypes.OrderBy(a => a.Name);
            return mapper.Map<IEnumerable<MediaType>, IEnumerable<MediaTypeBaseViewModel>>(mediaTypes);
        }

        // Track
        // TrackGetAllWithDetail - Sort the tracks by track name
        public IEnumerable<TrackWithDetailViewModel> TrackGetAllWithDetail()
        {
            var tracks = ds.Tracks
                            .Include("Album.Artist")
                            .Include("MediaType")
                            .OrderBy(t => t.Name);

            return mapper.Map<IEnumerable<Track>, IEnumerable<TrackWithDetailViewModel>>(tracks);
        }

        public TrackWithDetailViewModel TrackGetById(int id)
        {
            var track = ds.Tracks.Include("Album.Artist")
                                .Include("MediaType")
                                .SingleOrDefault(t => t.TrackId == id);
            if (track == null)
            {
                return null;
            }

            return mapper.Map<Track, TrackWithDetailViewModel>(track);
        }

        // TrackAdd
        public TrackWithDetailViewModel TrackAdd(TrackAddViewModel newTrack)
        {
            // Validate and fetch associated Album and MediaType
            var album = ds.Albums.Find(newTrack.AlbumId);
            var mediaType = ds.MediaTypes.Find(newTrack.MediaTypeId);

            if (album == null)
            {
                return null;
            }

            else
            {
                // Attempt to add the new item
                var addedItem = ds.Tracks.Add(mapper.Map<TrackAddViewModel, Track>(newTrack));
                addedItem.Album = album;
                addedItem.MediaType = mediaType;

                ds.SaveChanges();

                return (addedItem == null) ? null : mapper.Map<Track, TrackWithDetailViewModel>(addedItem);
            }            
        }

        // Playlist
        // PlaylistGetAll – Sort the playlists by playlist name
        public IEnumerable<PlaylistBaseViewModel> PlaylistGetAll()
        {
            var playlist = ds.Playlists
                                .Include("Tracks")
                                .OrderBy(p => p.Name);

            return playlist == null ? null : mapper.Map<IEnumerable<Playlist>, IEnumerable<PlaylistBaseViewModel>>(playlist);
        }

        public PlaylistWithTracksViewModel PlaylistGetById(int id)
        {
            var playlist = ds.Playlists
                             .Include("Tracks")
                             .SingleOrDefault(p => p.PlaylistId == id);

            return playlist == null ? null : mapper.Map<Playlist, PlaylistWithTracksViewModel>(playlist);
        }

        public PlaylistEditTracksViewModel PlaylistEditTracks(PlaylistEditTracksViewModel newItem)
        {
            var playlist = ds.Playlists
                            .Include("Tracks")
                            .SingleOrDefault(t => t.PlaylistId == newItem.PlaylistId);

            if (playlist == null)
            {
                return null;
            }
            else
            {
                // Update the object with the incoming values

                // First, clear out the existing collection
                playlist.Tracks.Clear();

                // Then, go through the incoming items
                // For each one, add to the fetched object's collection
                foreach (var trackId in newItem.TrackIds)
                {
                    var track = ds.Tracks.Find(trackId);
                    playlist.Tracks.Add(track);
                }
                // Save changes
                ds.SaveChanges();

                return mapper.Map<Playlist, PlaylistEditTracksViewModel>(playlist);
            }            
        }        
    }
}