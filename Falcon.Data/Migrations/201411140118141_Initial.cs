namespace Falcon.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admin",
                c => new
                    {
                        idMember = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idMember)
                .ForeignKey("dbo.Member", t => t.idMember)
                .Index(t => t.idMember);
            
            CreateTable(
                "dbo.Member",
                c => new
                    {
                        idMember = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        activation = c.Int(nullable: false),
                        city = c.String(maxLength: 255),
                        country = c.String(maxLength: 255),
                        firstname = c.String(maxLength: 255),
                        lastname = c.String(maxLength: 255),
                        password = c.String(maxLength: 255),
                        role = c.String(maxLength: 255),
                        status = c.String(maxLength: 255),
                        bankaccount_fk = c.Int(),
                        profilepic_fk = c.Int(),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idMember)
                .ForeignKey("dbo.BankAccount", t => t.bankaccount_fk)
                .ForeignKey("dbo.Document", t => t.profilepic_fk)
                .Index(t => t.bankaccount_fk)
                .Index(t => t.profilepic_fk);
            
            CreateTable(
                "dbo.BankAccount",
                c => new
                    {
                        idAccount = c.Int(nullable: false, identity: true),
                        balance = c.Double(),
                    })
                .PrimaryKey(t => t.idAccount);
            
            CreateTable(
                "dbo.CustomUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        Member_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Member", t => t.Member_Id)
                .Index(t => t.Member_Id);
            
            CreateTable(
                "dbo.Document",
                c => new
                    {
                        idDocument = c.Int(nullable: false, identity: true),
                        path = c.String(maxLength: 255),
                        type = c.String(maxLength: 255),
                        attach_id = c.Int(),
                    })
                .PrimaryKey(t => t.idDocument)
                .ForeignKey("dbo.Post", t => t.attach_id)
                .Index(t => t.attach_id);
            
            CreateTable(
                "dbo.CV",
                c => new
                    {
                        idCV = c.Int(nullable: false, identity: true),
                        languages = c.String(maxLength: 4000),
                        lastUpdate = c.DateTime(),
                        personalStatement = c.String(maxLength: 4000),
                        skills = c.String(maxLength: 4000),
                        targetJobs = c.String(maxLength: 4000),
                        workExperience = c.String(maxLength: 4000),
                        document_idDocument = c.Int(),
                    })
                .PrimaryKey(t => t.idCV)
                .ForeignKey("dbo.Document", t => t.document_idDocument)
                .Index(t => t.document_idDocument);
            
            CreateTable(
                "dbo.Freelancer",
                c => new
                    {
                        idMember = c.Int(nullable: false),
                        curriculum_idCV = c.Int(),
                    })
                .PrimaryKey(t => t.idMember)
                .ForeignKey("dbo.CV", t => t.curriculum_idCV)
                .ForeignKey("dbo.Member", t => t.idMember)
                .Index(t => t.idMember)
                .Index(t => t.curriculum_idCV);
            
            CreateTable(
                "dbo.Circle",
                c => new
                    {
                        idCircle = c.Int(nullable: false, identity: true),
                        description = c.String(maxLength: 255),
                        name = c.String(maxLength: 255),
                        type = c.String(maxLength: 255),
                        creator_fk = c.Int(),
                    })
                .PrimaryKey(t => t.idCircle)
                .ForeignKey("dbo.Freelancer", t => t.creator_fk)
                .Index(t => t.creator_fk);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        idPost = c.Int(nullable: false, identity: true),
                        content = c.String(maxLength: 255),
                        date = c.DateTime(),
                        poster_idMember = c.Int(),
                    })
                .PrimaryKey(t => t.idPost)
                .ForeignKey("dbo.Member", t => t.poster_idMember)
                .Index(t => t.poster_idMember);
            
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        idEvent = c.Int(nullable: false, identity: true),
                        description = c.String(maxLength: 255),
                        title = c.String(maxLength: 255),
                        creator_fk = c.Int(),
                    })
                .PrimaryKey(t => t.idEvent)
                .ForeignKey("dbo.Freelancer", t => t.creator_fk)
                .Index(t => t.creator_fk);
            
            CreateTable(
                "dbo.Mission",
                c => new
                    {
                        idMission = c.Int(nullable: false, identity: true),
                        budget = c.Double(),
                        deadline = c.DateTime(),
                        description = c.String(maxLength: 255),
                        duration = c.String(maxLength: 255),
                        plannedStart = c.DateTime(),
                        postDate = c.DateTime(),
                        status = c.String(maxLength: 255),
                        title = c.String(maxLength: 255),
                        category_idCategory = c.Int(),
                        evaluation_idEval = c.Int(),
                        owner_fk = c.Int(),
                        worker_id = c.Int(),
                    })
                .PrimaryKey(t => t.idMission)
                .ForeignKey("dbo.Category", t => t.category_idCategory)
                .ForeignKey("dbo.Evaluation", t => t.evaluation_idEval)
                .ForeignKey("dbo.Freelancer", t => t.worker_id)
                .ForeignKey("dbo.Owner", t => t.owner_fk)
                .Index(t => t.category_idCategory)
                .Index(t => t.evaluation_idEval)
                .Index(t => t.owner_fk)
                .Index(t => t.worker_id);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        idCategory = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 255),
                        parent_idCategory = c.Int(),
                    })
                .PrimaryKey(t => t.idCategory)
                .ForeignKey("dbo.Category", t => t.parent_idCategory)
                .Index(t => t.parent_idCategory);
            
            CreateTable(
                "dbo.Complaint",
                c => new
                    {
                        idComplaint = c.Int(nullable: false, identity: true),
                        body = c.String(maxLength: 255),
                        sendDate = c.DateTime(),
                        status = c.String(maxLength: 255),
                        subject = c.String(maxLength: 255),
                        defendant_fk = c.Int(),
                        mission_fk = c.Int(),
                        plaintiff_fk = c.Int(),
                    })
                .PrimaryKey(t => t.idComplaint)
                .ForeignKey("dbo.Freelancer", t => t.defendant_fk)
                .ForeignKey("dbo.Mission", t => t.mission_fk)
                .ForeignKey("dbo.Owner", t => t.plaintiff_fk)
                .Index(t => t.defendant_fk)
                .Index(t => t.mission_fk)
                .Index(t => t.plaintiff_fk);
            
            CreateTable(
                "dbo.Owner",
                c => new
                    {
                        idMember = c.Int(nullable: false),
                        companyDescription = c.String(maxLength: 255),
                        companyName = c.String(maxLength: 255),
                        c_logo_fk = c.Int(),
                    })
                .PrimaryKey(t => t.idMember)
                .ForeignKey("dbo.Document", t => t.c_logo_fk)
                .ForeignKey("dbo.Member", t => t.idMember)
                .Index(t => t.idMember)
                .Index(t => t.c_logo_fk);
            
            CreateTable(
                "dbo.Evaluation",
                c => new
                    {
                        idEval = c.Int(nullable: false),
                        date = c.DateTime(),
                        feedback = c.String(maxLength: 255),
                        score = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.idEval);
            
            CreateTable(
                "dbo.PrivateMessage",
                c => new
                    {
                        idPM = c.Int(nullable: false, identity: true),
                        body = c.String(maxLength: 255),
                        date = c.DateTime(),
                        receiver_fk = c.Int(),
                        sender_fk = c.Int(),
                    })
                .PrimaryKey(t => t.idPM)
                .ForeignKey("dbo.Freelancer", t => t.receiver_fk)
                .ForeignKey("dbo.Freelancer", t => t.sender_fk)
                .Index(t => t.receiver_fk)
                .Index(t => t.sender_fk);
            
            CreateTable(
                "dbo.CustomUserLogins",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        Member_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey })
                .ForeignKey("dbo.Member", t => t.Member_Id)
                .Index(t => t.Member_Id);
            
            CreateTable(
                "dbo.CustomUserRoles",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        Member_Id = c.Int(),
                        CustomRole_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Member", t => t.Member_Id)
                .ForeignKey("dbo.CustomRoles", t => t.CustomRole_Id)
                .Index(t => t.Member_Id)
                .Index(t => t.CustomRole_Id);
            
            CreateTable(
                "dbo.hibernate_sequences",
                c => new
                    {
                        sequence_name = c.String(nullable: false, maxLength: 255),
                        next_val = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.sequence_name);
            
            CreateTable(
                "dbo.CustomRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Circle_Freelancer",
                c => new
                    {
                        Circle_idCircle = c.Int(nullable: false),
                        freelancers_idMember = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Circle_idCircle, t.freelancers_idMember })
                .ForeignKey("dbo.Circle", t => t.Circle_idCircle, cascadeDelete: true)
                .ForeignKey("dbo.Freelancer", t => t.freelancers_idMember, cascadeDelete: true)
                .Index(t => t.Circle_idCircle)
                .Index(t => t.freelancers_idMember);
            
            CreateTable(
                "dbo.Circle_Post",
                c => new
                    {
                        posts_idPost = c.Int(nullable: false),
                        Circle_idCircle = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.posts_idPost, t.Circle_idCircle })
                .ForeignKey("dbo.Post", t => t.posts_idPost, cascadeDelete: true)
                .ForeignKey("dbo.Circle", t => t.Circle_idCircle, cascadeDelete: true)
                .Index(t => t.posts_idPost)
                .Index(t => t.Circle_idCircle);
            
            CreateTable(
                "dbo.Event_Freelancer",
                c => new
                    {
                        joinedEvents_idEvent = c.Int(nullable: false),
                        participants_idMember = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.joinedEvents_idEvent, t.participants_idMember })
                .ForeignKey("dbo.Event", t => t.joinedEvents_idEvent, cascadeDelete: true)
                .ForeignKey("dbo.Freelancer", t => t.participants_idMember, cascadeDelete: true)
                .Index(t => t.joinedEvents_idEvent)
                .Index(t => t.participants_idMember);
            
            CreateTable(
                "dbo.Event_Post",
                c => new
                    {
                        posts_idPost = c.Int(nullable: false),
                        Event_idEvent = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.posts_idPost, t.Event_idEvent })
                .ForeignKey("dbo.Post", t => t.posts_idPost, cascadeDelete: true)
                .ForeignKey("dbo.Event", t => t.Event_idEvent, cascadeDelete: true)
                .Index(t => t.posts_idPost)
                .Index(t => t.Event_idEvent);
            
            CreateTable(
                "dbo.Category_Category",
                c => new
                    {
                        subCategories_idCategory = c.Int(nullable: false),
                        Category_idCategory = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.subCategories_idCategory, t.Category_idCategory })
                .ForeignKey("dbo.Category", t => t.subCategories_idCategory)
                .ForeignKey("dbo.Category", t => t.Category_idCategory)
                .Index(t => t.subCategories_idCategory)
                .Index(t => t.Category_idCategory);
            
            CreateTable(
                "dbo.Mission_Post",
                c => new
                    {
                        posts_idPost = c.Int(nullable: false),
                        Mission_idMission = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.posts_idPost, t.Mission_idMission })
                .ForeignKey("dbo.Post", t => t.posts_idPost, cascadeDelete: true)
                .ForeignKey("dbo.Mission", t => t.Mission_idMission, cascadeDelete: true)
                .Index(t => t.posts_idPost)
                .Index(t => t.Mission_idMission);
            
            CreateTable(
                "dbo.friends_lists",
                c => new
                    {
                        freelancer_1 = c.Int(nullable: false),
                        freelancer_2 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.freelancer_1, t.freelancer_2 })
                .ForeignKey("dbo.Freelancer", t => t.freelancer_1)
                .ForeignKey("dbo.Freelancer", t => t.freelancer_2)
                .Index(t => t.freelancer_1)
                .Index(t => t.freelancer_2);
            
            CreateTable(
                "dbo.Mission_Freelancer",
                c => new
                    {
                        freelancers_idMember = c.Int(nullable: false),
                        Mission_idMission = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.freelancers_idMember, t.Mission_idMission })
                .ForeignKey("dbo.Freelancer", t => t.freelancers_idMember, cascadeDelete: true)
                .ForeignKey("dbo.Mission", t => t.Mission_idMission, cascadeDelete: true)
                .Index(t => t.freelancers_idMember)
                .Index(t => t.Mission_idMission);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomUserRoles", "CustomRole_Id", "dbo.CustomRoles");
            DropForeignKey("dbo.Admin", "idMember", "dbo.Member");
            DropForeignKey("dbo.CustomUserRoles", "Member_Id", "dbo.Member");
            DropForeignKey("dbo.CustomUserLogins", "Member_Id", "dbo.Member");
            DropForeignKey("dbo.Member", "profilepic_fk", "dbo.Document");
            DropForeignKey("dbo.Document", "attach_id", "dbo.Post");
            DropForeignKey("dbo.PrivateMessage", "sender_fk", "dbo.Freelancer");
            DropForeignKey("dbo.PrivateMessage", "receiver_fk", "dbo.Freelancer");
            DropForeignKey("dbo.Mission_Freelancer", "Mission_idMission", "dbo.Mission");
            DropForeignKey("dbo.Mission_Freelancer", "freelancers_idMember", "dbo.Freelancer");
            DropForeignKey("dbo.Freelancer", "idMember", "dbo.Member");
            DropForeignKey("dbo.friends_lists", "freelancer_2", "dbo.Freelancer");
            DropForeignKey("dbo.friends_lists", "freelancer_1", "dbo.Freelancer");
            DropForeignKey("dbo.Freelancer", "curriculum_idCV", "dbo.CV");
            DropForeignKey("dbo.Mission_Post", "Mission_idMission", "dbo.Mission");
            DropForeignKey("dbo.Mission_Post", "posts_idPost", "dbo.Post");
            DropForeignKey("dbo.Mission", "owner_fk", "dbo.Owner");
            DropForeignKey("dbo.Mission", "worker_id", "dbo.Freelancer");
            DropForeignKey("dbo.Mission", "evaluation_idEval", "dbo.Evaluation");
            DropForeignKey("dbo.Complaint", "plaintiff_fk", "dbo.Owner");
            DropForeignKey("dbo.Owner", "idMember", "dbo.Member");
            DropForeignKey("dbo.Owner", "c_logo_fk", "dbo.Document");
            DropForeignKey("dbo.Complaint", "mission_fk", "dbo.Mission");
            DropForeignKey("dbo.Complaint", "defendant_fk", "dbo.Freelancer");
            DropForeignKey("dbo.Mission", "category_idCategory", "dbo.Category");
            DropForeignKey("dbo.Category", "parent_idCategory", "dbo.Category");
            DropForeignKey("dbo.Category_Category", "Category_idCategory", "dbo.Category");
            DropForeignKey("dbo.Category_Category", "subCategories_idCategory", "dbo.Category");
            DropForeignKey("dbo.Post", "poster_idMember", "dbo.Member");
            DropForeignKey("dbo.Event_Post", "Event_idEvent", "dbo.Event");
            DropForeignKey("dbo.Event_Post", "posts_idPost", "dbo.Post");
            DropForeignKey("dbo.Event_Freelancer", "participants_idMember", "dbo.Freelancer");
            DropForeignKey("dbo.Event_Freelancer", "joinedEvents_idEvent", "dbo.Event");
            DropForeignKey("dbo.Event", "creator_fk", "dbo.Freelancer");
            DropForeignKey("dbo.Circle_Post", "Circle_idCircle", "dbo.Circle");
            DropForeignKey("dbo.Circle_Post", "posts_idPost", "dbo.Post");
            DropForeignKey("dbo.Circle_Freelancer", "freelancers_idMember", "dbo.Freelancer");
            DropForeignKey("dbo.Circle_Freelancer", "Circle_idCircle", "dbo.Circle");
            DropForeignKey("dbo.Circle", "creator_fk", "dbo.Freelancer");
            DropForeignKey("dbo.CV", "document_idDocument", "dbo.Document");
            DropForeignKey("dbo.CustomUserClaims", "Member_Id", "dbo.Member");
            DropForeignKey("dbo.Member", "bankaccount_fk", "dbo.BankAccount");
            DropIndex("dbo.Mission_Freelancer", new[] { "Mission_idMission" });
            DropIndex("dbo.Mission_Freelancer", new[] { "freelancers_idMember" });
            DropIndex("dbo.friends_lists", new[] { "freelancer_2" });
            DropIndex("dbo.friends_lists", new[] { "freelancer_1" });
            DropIndex("dbo.Mission_Post", new[] { "Mission_idMission" });
            DropIndex("dbo.Mission_Post", new[] { "posts_idPost" });
            DropIndex("dbo.Category_Category", new[] { "Category_idCategory" });
            DropIndex("dbo.Category_Category", new[] { "subCategories_idCategory" });
            DropIndex("dbo.Event_Post", new[] { "Event_idEvent" });
            DropIndex("dbo.Event_Post", new[] { "posts_idPost" });
            DropIndex("dbo.Event_Freelancer", new[] { "participants_idMember" });
            DropIndex("dbo.Event_Freelancer", new[] { "joinedEvents_idEvent" });
            DropIndex("dbo.Circle_Post", new[] { "Circle_idCircle" });
            DropIndex("dbo.Circle_Post", new[] { "posts_idPost" });
            DropIndex("dbo.Circle_Freelancer", new[] { "freelancers_idMember" });
            DropIndex("dbo.Circle_Freelancer", new[] { "Circle_idCircle" });
            DropIndex("dbo.CustomUserRoles", new[] { "CustomRole_Id" });
            DropIndex("dbo.CustomUserRoles", new[] { "Member_Id" });
            DropIndex("dbo.CustomUserLogins", new[] { "Member_Id" });
            DropIndex("dbo.PrivateMessage", new[] { "sender_fk" });
            DropIndex("dbo.PrivateMessage", new[] { "receiver_fk" });
            DropIndex("dbo.Owner", new[] { "c_logo_fk" });
            DropIndex("dbo.Owner", new[] { "idMember" });
            DropIndex("dbo.Complaint", new[] { "plaintiff_fk" });
            DropIndex("dbo.Complaint", new[] { "mission_fk" });
            DropIndex("dbo.Complaint", new[] { "defendant_fk" });
            DropIndex("dbo.Category", new[] { "parent_idCategory" });
            DropIndex("dbo.Mission", new[] { "worker_id" });
            DropIndex("dbo.Mission", new[] { "owner_fk" });
            DropIndex("dbo.Mission", new[] { "evaluation_idEval" });
            DropIndex("dbo.Mission", new[] { "category_idCategory" });
            DropIndex("dbo.Event", new[] { "creator_fk" });
            DropIndex("dbo.Post", new[] { "poster_idMember" });
            DropIndex("dbo.Circle", new[] { "creator_fk" });
            DropIndex("dbo.Freelancer", new[] { "curriculum_idCV" });
            DropIndex("dbo.Freelancer", new[] { "idMember" });
            DropIndex("dbo.CV", new[] { "document_idDocument" });
            DropIndex("dbo.Document", new[] { "attach_id" });
            DropIndex("dbo.CustomUserClaims", new[] { "Member_Id" });
            DropIndex("dbo.Member", new[] { "profilepic_fk" });
            DropIndex("dbo.Member", new[] { "bankaccount_fk" });
            DropIndex("dbo.Admin", new[] { "idMember" });
            DropTable("dbo.Mission_Freelancer");
            DropTable("dbo.friends_lists");
            DropTable("dbo.Mission_Post");
            DropTable("dbo.Category_Category");
            DropTable("dbo.Event_Post");
            DropTable("dbo.Event_Freelancer");
            DropTable("dbo.Circle_Post");
            DropTable("dbo.Circle_Freelancer");
            DropTable("dbo.CustomRoles");
            DropTable("dbo.hibernate_sequences");
            DropTable("dbo.CustomUserRoles");
            DropTable("dbo.CustomUserLogins");
            DropTable("dbo.PrivateMessage");
            DropTable("dbo.Evaluation");
            DropTable("dbo.Owner");
            DropTable("dbo.Complaint");
            DropTable("dbo.Category");
            DropTable("dbo.Mission");
            DropTable("dbo.Event");
            DropTable("dbo.Post");
            DropTable("dbo.Circle");
            DropTable("dbo.Freelancer");
            DropTable("dbo.CV");
            DropTable("dbo.Document");
            DropTable("dbo.CustomUserClaims");
            DropTable("dbo.BankAccount");
            DropTable("dbo.Member");
            DropTable("dbo.Admin");
        }
    }
}
