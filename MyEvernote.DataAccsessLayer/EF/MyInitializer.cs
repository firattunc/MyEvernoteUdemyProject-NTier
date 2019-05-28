using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MyEvernote.Entities;

namespace MyEvernote.DataAccsessLayer.EF
{
    public class MyInitializer:CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            EvernoteUser admin = new EvernoteUser()
            {
                Name = "Murat",
                SurName = "Baseren",
                Email = "kadirmuratbaseren@gmail.com",
                ActivateGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = true,
                UserName="muratbaseren",
                Password="12345",
                CreatedOn=DateTime.Now,
                ModifiedOn=DateTime.Now.AddMinutes(5),
                ModifiedUserName="muratbaseren"

                
            };
            EvernoteUser standartUser = new EvernoteUser()
            {
                Name = "Kadir",
                SurName = "Baseren",
                Email = "kadirmuratbaseren@gmail.com",
                ActivateGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = false,
                UserName = "kadirbaseren",
                Password = "54321",
                CreatedOn = DateTime.Now.AddHours(1),
                ModifiedOn = DateTime.Now.AddMinutes(65),
                ModifiedUserName = "muratbaseren"


            };
            context.EvernoteUsers.Add(admin);
            context.EvernoteUsers.Add(standartUser);

            for (int i = 0; i < 8; i++)
            {
                EvernoteUser user = new EvernoteUser()
                {
                    Name = FakeData.NameData.GetFirstName(),
                    SurName = FakeData.NameData.GetSurname(),
                    Email = FakeData.NetworkData.GetEmail(),
                    ActivateGuid = Guid.NewGuid(),
                    IsActive = true,
                    IsAdmin = false,
                    UserName = $"user{i}",
                    Password = "123",
                    CreatedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                    ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                    ModifiedUserName = $"user{i}"
                };
                context.EvernoteUsers.Add(user);
            }

            context.SaveChanges();
            //user list
            List<EvernoteUser> userList = context.EvernoteUsers.ToList();
            //adding fake kategori
            for (int i = 0; i < 10; i++)
            {
                Kategori kat = new Kategori()
                {
                    Title = FakeData.PlaceData.GetStreetName(),
                    Description = FakeData.PlaceData.GetAddress(),
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    ModifiedUserName = "muratbaseren"
                };
                context.Kategories.Add(kat);
                //adding notes
                for (int k = 0; k < FakeData.NumberData.GetNumber(5,9); k++)
                {
                    EvernoteUser owner = userList[FakeData.NumberData.GetNumber(0, userList.Count - 1)];
                    Note note = new Note()
                    {
                        Title = FakeData.TextData.GetAlphabetical(FakeData.NumberData.GetNumber(5, 25)),
                        Text = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(1, 3)),
                        IsDraft = false,
                        LikeCount = FakeData.NumberData.GetNumber(1, 9),
                        Owner = owner,
                        CreatedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                        ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                        ModifiedUserName = owner.UserName
                    };
                    
                    kat.notes.Add(note);
                    //adding comments
                    for (int a = 0; a < FakeData.NumberData.GetNumber(3, 5); a++)
                    {
                        EvernoteUser owner_comment = userList[FakeData.NumberData.GetNumber(0, userList.Count - 1)];
                        Comment comment = new Comment()
                        {
                            Text = FakeData.TextData.GetSentence(),
                            Owner= owner_comment,
                            CreatedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                            ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                            ModifiedUserName = owner_comment.UserName,

                        };

                        note.Comments.Add(comment);

                    }
                    //adding likes

                    
                    for (int j = 0; j < note.LikeCount; j++)
                    {

                        Liked liked = new Liked()
                        {
                            LikedUser = userList[j]

                        };
                        note.Likes.Add(liked);
                    }
                }
               
            }
            context.SaveChanges();
        }
    }
}
