using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bewander.DAL;
using Bewander.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace Bewander.Controllers
{
    public class UserProfilesController : Controller
    {
        private BewanderContext db = new BewanderContext();
        protected ApplicationDbContext ApplicationDbContext { get; set; }
        protected UserManager<ApplicationUser> UserManager { get; set; }

        // GET: UserProfiles
        public ActionResult Index()
        {
            return View(db.UserProfiles.ToList());
        }

        // GET: Specific UserProfile information        
        public ActionResult ProfilePage()
        {
            // CREATE: ViewModel using (db.User, db.UserProfile, db.Review)
            var userProfileViewModel = new UserProfileViewModel();

            string userID = GetUserID();
            userProfileViewModel.User = GetUser(userID);
            userProfileViewModel.UserProfile = GetUserProfile(userID);
            userProfileViewModel.Reviews = GetReviews(userID);
            userProfileViewModel.Avatar = GetAvatar(userID);
            userProfileViewModel.CoverPhoto = GetCoverPhoto(userID);
            userProfileViewModel.Photos = GetPhotos(userID);

            // NULL userID: 404 error
            if (userID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // POST: Send values from allReviews to page for display
            return View(userProfileViewModel);
        }

        // GET: UserProfiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //UserProfile userProfile = db.UserProfiles.Find(id);
            UserProfile userProfile = db.UserProfiles.Include(s => s.Files).SingleOrDefault(s => s.UserProfileID == id);
            if (userProfile == null)
            {
                return HttpNotFound();
            }
            return View(userProfile);
        }

        // GET: UserProfiles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserProfiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserProfileID,UserID,About,HomeTown,TravelLocations,FavoriteLocation")] UserProfile userProfile)
        {
            if (ModelState.IsValid)
            {
                db.UserProfiles.Add(userProfile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userProfile);
        }

        // GET: UserProfiles/Edit/5
        public ActionResult Edit(int? id)
        {
            //GET: UserProfileID
            id = GetUserProfileID();

            // NULL UserProfileID: 404 error
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            UserProfile userProfile = db.UserProfiles.Find(id);

            if (userProfile == null)
            {
                return HttpNotFound();
            }

            return View(userProfile);
        }

        // POST: UserProfiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserProfileID,UserID,About,HomeTown,TravelLocations,FavoriteLocation")] UserProfile userProfile, 
                                 [Bind(Include = "FileID,FileName,ContentType,Content,FileType,UserID")] HttpPostedFileBase uploadProfile,
                                 [Bind(Include = "FileID,FileName,ContentType,Content,FileType,UserID")] HttpPostedFileBase coverPhoto,
                                 [Bind(Include = "FileID,FileName,ContentType,Content,FileType,UserID")] IEnumerable<HttpPostedFileBase> uploadPhoto)
        {
            // GET: UserID
            string userID = GetUserID();

            if (ModelState.IsValid)
            {
                // Profile Picture (Avatar) 
                if (uploadProfile != null && uploadProfile.ContentLength > 0)
                {
                    SavePhoto(userID, uploadProfile, "Avatar");
                }

                // Cover Photo 
                if (coverPhoto != null && coverPhoto.ContentLength > 0)
                {
                    SavePhoto(userID, coverPhoto, "CoverPhoto");
                }

                // Photo(s)
                // FOREACH: If multiple photos were uploaded.
                foreach (var photo in uploadPhoto)
                {                 
                    if (photo != null && photo.ContentLength > 0)
                    {
                        SavePhoto(userID, photo, "Photo");
                    }
                }

                userProfile.UserID = userID;
                db.Entry(userProfile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ProfilePage");
            }
            return View(userProfile);
        }

        // GET: UserProfiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProfile userProfile = db.UserProfiles.Find(id);
            if (userProfile == null)
            {
                return HttpNotFound();
            }
            return View(userProfile);
        }

        // POST: UserProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserProfile userProfile = db.UserProfiles.Find(id);
            db.UserProfiles.Remove(userProfile);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public string GetUserID()
        {
            // GET: Current Users ID
            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            // SET: UserID
            string userID = user.Id;

            return (userID);
        }

        public int GetUserProfileID()
        {
            string userID = GetUserID();

            // SELECT: UserProfileID
            var userProfiles = db.UserProfiles
                            .Where(u => u.UserID == userID)
                            .Select(u => u.UserProfileID)
                            .ToList();

            // NULL userProfiles: 404 error
            if (userProfiles == null)
            {
                return (0);
            }

            // GET: UserProfileID value from userProfiles 
            int userProfileID = userProfiles[0];
            return (userProfileID);
        }

        public User GetUser(string userID)
        {
            // SELECT: User with matching UserID
            var user = db.Users
                        .Where(r => r.UserID == userID)
                        .FirstOrDefault();        
            return (user);
        }

        public UserProfile GetUserProfile(string userID)
        {
            // SELECT: Userprofile with matching UserID
            var userProfile = db.UserProfiles
                                .Where(r => r.UserID == userID)
                                .FirstOrDefault();
            return (userProfile);
        }

        public List<Review> GetReviews(string userID)
        {
            // SELECT: Reviews with matching UserID
            var allReviews = db.Reviews
                               .Where(r => r.UserID == userID)
                               .OrderByDescending(r => r.ReviewID)
                               .ToList();
            return (allReviews);
        }

        public List<File> GetFiles(string userID)
        {
            // SELECT: Files with matching UserID
            var allFiles = db.Files
                               .Where(r => r.UserID == userID)
                               .OrderByDescending(r => r.FileID)
                               .ToList();

            return (allFiles);
        }

        public List<File> GetAvatar(string userID)
        {
            // SELECT: Files with matching UserID
            var allFiles = db.Files
                               .Where(r => r.UserID == userID && r.FileType == FileType.Avatar)
                               .OrderByDescending(r => r.FileID)
                               .ToList();

            return (allFiles);
        }

        public List<File> GetCoverPhoto(string userID)
        {
            // SELECT: Files with matching UserID
            var allFiles = db.Files
                               .Where(r => r.UserID == userID && r.FileType == FileType.CoverPhoto)
                               .OrderByDescending(r => r.FileID)
                               .ToList();

            return (allFiles);
        }

        public List<File> GetPhotos(string userID)
        {
            // SELECT: Files with matching UserID
            var allFiles = db.Files
                               .Where(r => r.UserID == userID && r.FileType == FileType.Photos)
                               .OrderByDescending(r => r.FileID)
                               .ToList();

            return (allFiles);
        }

        public void SavePhoto(string userID, HttpPostedFileBase Photo, string PhotoType)
        {
            UserProfile userProfile = new UserProfile();
            var uploadPhoto = new File();

            switch (PhotoType)
            {
                case "Avatar":
                    uploadPhoto = new File
                    {
                        FileName = System.IO.Path.GetFileName(Photo.FileName),
                        FileType = FileType.Avatar,
                        ContentType = Photo.ContentType,
                        UserID = userID
                    };
                    break;
                case "CoverPhoto":
                     uploadPhoto = new File
                    {
                        FileName = System.IO.Path.GetFileName(Photo.FileName),
                        FileType = FileType.CoverPhoto,
                        ContentType = Photo.ContentType,
                        UserID = userID
                    };
                    break;
                default:
                    uploadPhoto = new File
                    {
                        FileName = System.IO.Path.GetFileName(Photo.FileName),
                        FileType = FileType.Photos,
                        ContentType = Photo.ContentType,
                        UserID = userID
                    };
                    break;
            }
            
            using (var reader = new System.IO.BinaryReader(Photo.InputStream))
            {
                uploadPhoto.Content = reader.ReadBytes(Photo.ContentLength);
            }

            File file = uploadPhoto;
            userProfile.Files = new List<File> { uploadPhoto };
            db.Files.Add(file);
            db.SaveChanges();
        }

    }
}
