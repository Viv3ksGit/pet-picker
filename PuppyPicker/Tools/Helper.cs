using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using Firebase.Storage;
using PuppyPicker.ViewModels;

namespace PuppyPicker.Tools
{
    public class Helper
    {
        //connect to Google Firebase Storage
        public class FirebaseStorageHelper
        {
            FirebaseStorage firebaseStorage = new FirebaseStorage("puppypicker-dd153.appspot.com");

            public async Task<string> UploadFile(Stream fileStream, string fileName)
            {
                var imageUrl = await firebaseStorage
                    .Child("breeds")
                    .Child(fileName)
                    .PutAsync(fileStream);
                return imageUrl;
            }

            public async Task<string> GetFile(string fileName)
            {
                return await firebaseStorage
                    .Child("breeds")
                    .Child(fileName)
                    .GetDownloadUrlAsync();
            }

            public async Task DeleteFile(string fileName)
            {
                await firebaseStorage
                     .Child("breeds")
                     .Child(fileName)
                     .DeleteAsync();
            }
        }

        //connect to Google Firebase Realtime DB
        public class FirebaseHelper
        {
            FirebaseClient firebase = new FirebaseClient("https://puppypicker-dd153.firebaseio.com/");

            public async Task<List<DogProfilePageVM>> GetAllDogs()
            {
                return (await firebase
                  .Child("Dogs")
                  .OnceAsync<DogProfilePageVM>()
                  )
                  .Select(
                     item =>
                    {
                        return new DogProfilePageVM
                        {
                            DogPP_Title = item.Object.DogPP_Title,
                            Description = item.Object.Description,
                            ImageFile = item.Object.ImageFile
                        };
                    }).ToList();
            }

            public async Task<List<DogProfilePageVM>> GetFavouritesDogs()
            {
                return (await firebase
                  .Child("Dogs")
                  .OrderBy("DogPP_Title")
                  .LimitToFirst(5)
                  .OnceAsync<DogProfilePageVM>()
                  )
                  .Select(
                     item =>
                     {
                         return new DogProfilePageVM
                         {
                             DogPP_Title = item.Object.DogPP_Title,
                             ImageFile = item.Object.ImageFile
                         };
                     }).ToList();
            }

            public async Task<DogProfilePageVM> GetDog(string DogPP_Title)
            {
                var allDogs = await GetAllDogs();
                await firebase
                  .Child("Dogs")
                  .OnceAsync<DogProfilePageVM>();
                return allDogs.Where(a => a.DogPP_Title == DogPP_Title).FirstOrDefault();
            }

            public async Task<List<MatchPageVM>> GetQuizQuestions()
            {
                return (await firebase
                  .Child("Quiz")
                  .OnceAsync<MatchPageVM>()
                  )
                  .Select(
                     item =>
                     {
                         return new MatchPageVM
                         {
                             question = item.Object.question,
                             answer1 = item.Object.answer1,
                             answer2 = item.Object.answer2,
                             answer3 = item.Object.answer3,
                             answer4 = item.Object.answer4,
                             answer5 = item.Object.answer5
                         };
                     }).ToList();
            }
        }
    }
}
