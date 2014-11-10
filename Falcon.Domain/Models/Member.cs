using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Falcon.Domain.Models
{
    public partial class Member : IdentityUser<int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public Member()
        {
            this.Posts = new List<Post>();
        }

        public override string UserName
        {
            get { return username; }
            set { base.UserName = value;
                username = value;
            }
        }

        public int idMember { get; set; }
        public int activation { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string email { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public string status { get; set; }
        public string username { get; set; }
        public Nullable<int> bankaccount_fk { get; set; }
        public Nullable<int> profilepic_fk { get; set; }
        public virtual Admin Admin { get; set; }
        public virtual BankAccount BankAccount { get; set; }
        public virtual Document Document { get; set; }
        public virtual Freelancer Freelancer { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual Owner Owner { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(
             UserManager<Member, int> manager)
        {
            // Note the authenticationType must match the one defined in
            // CookieAuthenticationOptions.AuthenticationType 
            var userIdentity = await manager.CreateIdentityAsync(
                this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here 
            return userIdentity;
        }
    }

    public class CustomUserRole : IdentityUserRole<int>
    {
        [Key, Column(Order = 0)]
        public override int UserId
        {
            get { return base.UserId; }
            set { base.UserId = value; }
        }

      [Key, Column(Order = 1)]
          public override int RoleId
        {
            get { return base.RoleId; }
            set { base.RoleId = value; }
        }
    }

    public class CustomUserClaim : IdentityUserClaim<int>
    {
        [Key]
        public override int Id
        {
            get { return base.Id; }
            set { base.Id = value; }
        }
    }

    public class CustomUserLogin : IdentityUserLogin<int>
    {
        [Key, Column(Order = 0)]
        public override int UserId
        {
            get { return base.UserId; }
            set { base.UserId = value; }
        }

      [Key, Column(Order = 1)]
          public override string LoginProvider
        {
            get { return base.LoginProvider; }
            set { base.LoginProvider = value; }
        }

      [Key, Column(Order = 3)]
          public override string ProviderKey
        {
            get { return base.ProviderKey; }
            set { base.ProviderKey = value; }
        }
    } 
}
