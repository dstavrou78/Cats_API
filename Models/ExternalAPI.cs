using Cats_API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cats_API.Models
{
    
    public class ExternalAPI : IExternalAPI
    {
        public ExternalAPI()
        {
            // ...
        }
        public async Task GetAsync(HttpClient httpClient, CatsContext db, string? api_key)
        {
            if (api_key != null && !httpClient.DefaultRequestHeaders.Contains("x-api-key"))
            {
                httpClient.DefaultRequestHeaders.Add("x-api-key", api_key);
            }
            using HttpResponseMessage response = await httpClient.GetAsync("v1/images/search?limit=25&has_breeds=1");

            if (response.EnsureSuccessStatusCode().StatusCode == System.Net.HttpStatusCode.OK)
            {
                var Images = await response.Content.ReadFromJsonAsync<List<Image>>();

                if (Images != null)
                {
                    foreach (Image img in Images)
                    {
                        if (!db.Cats.Any(x => x.CatId.ToLower() == img.Id.ToLower()))
                        {
                            Cat cat = new Cat();
                            cat.CatId = img.Id;
                            cat.Height = img.Height;
                            cat.Width = img.Width;

                            Image InsImage = new Image();
                            InsImage.Id = img.Id;
                            InsImage.Height = img.Height;
                            InsImage.Width = img.Width;

                            if (img.Breeds != null)
                            {
                                foreach (Breed? breed in img.Breeds)
                                {

                                    //if (db.Breeds.Any(b => b.Id.ToLower().Trim() == breed.Id.ToLower().Trim()))
                                    //{
                                    //    InsImage.Breeds.Add(db.Breeds.Where(b => b.Id.ToLower().Trim() == breed.Id.ToLower().Trim()).First());
                                    //}
                                    //else
                                    //{
                                    //    InsImage.Breeds.Add(breed);
                                    //}
                                    InsImage.Breeds.Add(db.GetExistingOrNew<Breed>(breed, "Id"));

                                    // Tags
                                    if (breed.Temperament != null && breed.Temperament.Trim().Length > 0)
                                    {
                                        foreach (string temperament in breed.Temperament.Split(","))
                                        {
                                            if (db.Tags.Any(t => t.Name.ToLower().Trim() == temperament.ToLower().Trim()))
                                            {
                                                cat.Tags.Add(db.Tags.Where(t => t.Name.ToLower().Trim() == temperament.ToLower().Trim()).First());
                                            }
                                            else
                                            {
                                                Tag tag = new Tag();
                                                tag.Name = temperament.Trim();
                                                cat.Tags.Add(tag);
                                            }
                                        }
                                    }
                                }
                            }
                            cat.Image = InsImage;
                            db.Cats.Add(cat);
                            try
                            {
                                await db.SaveChangesAsync();
                            }
                            catch (DbUpdateConcurrencyException)
                            {
                            }
                        }
                    }
                }
            }
        }
    }
}
