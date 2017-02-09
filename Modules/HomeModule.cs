using Nancy;
using System.Collections.Generic;
using Album.Objects;

namespace Album
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
    }
  }
}
