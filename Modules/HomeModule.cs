using Nancy;
using System.Collections.Generic;
using AlbumCollection.Objects;

namespace AlbumCollection
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };

      Get["/artists"] = _ => {
        List<Artist> allArtists = Artist.GetAll();
        return View["artists.cshtml", allArtists];
      };
      Get["/artist/new"] = _ => {
        return View["add_artist.cshtml"];
      };
      Post["/artists"] = _ => {
        Artist newArtist = new Artist(Request.Form["artist-name"]);
        List<Artist> allArtists = Artist.GetAll();
        return View["artists.cshtml", allArtists];
      };
      Get["/artists/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Artist selectedArtist = Artist.Find(parameters.id);
        List<Album> artistAlbums = selectedArtist.GetAlbums();
        model.Add("artist", selectedArtist);
        model.Add("albums", artistAlbums);
        return View["artist.cshtml", model];
      };
      Get["/artist/{id}/album/new"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Artist selectedArtist = Artist.Find(parameters.id);
        List<Album> allAlbums = selectedArtist.GetAlbums();
        model.Add("artist", selectedArtist);
        model.Add("album", allAlbums);
        return View["artist_albums_form.cshtml", model];
      };
      Post["/artist/albums"] = _ => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Artist selectedArtist = Artist.Find(Request.Form["artist-id"]);
        List<Album> artistAlbums = selectedArtist.GetAlbums();
        string albumName = Request.Form["albums"];
        Album newAlbum = new Album(albumName);
        artistAlbums.Add(newAlbum);
        model.Add("albums", artistAlbums);
        model.Add("artist", selectedArtist);
        return View["artist.cshtml", model];
      };
    }
  }
}
