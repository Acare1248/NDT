using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebNDTIT01.Models
{
    public partial class ndt_dbContext : DbContext
    {
        public ndt_dbContext()
        {
        }

        public ndt_dbContext(DbContextOptions<ndt_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EfmigrationsHistory> EfmigrationsHistories { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<ExecutionError> ExecutionErrors { get; set; }
        public virtual DbSet<ExecutionPointer> ExecutionPointers { get; set; }
        public virtual DbSet<ExtensionAttribute> ExtensionAttributes { get; set; }
        public virtual DbSet<MailreportlogTbCollectionsYearMonth> MailreportlogTbCollectionsYearMonths { get; set; }
        public virtual DbSet<ScheduledCommand> ScheduledCommands { get; set; }
        public virtual DbSet<Subscription> Subscriptions { get; set; }
        public virtual DbSet<TbAntiVirusinfo> TbAntiVirusinfos { get; set; }
        public virtual DbSet<TbComputerAssetNo> TbComputerAssetNos { get; set; }
        public virtual DbSet<TbComputerList> TbComputerLists { get; set; }
        public virtual DbSet<TbConfigDeviceOfReport> TbConfigDeviceOfReports { get; set; }
        public virtual DbSet<TbConfigMailReport> TbConfigMailReports { get; set; }
        public virtual DbSet<TbDeviceMatchType> TbDeviceMatchTypes { get; set; }
        public virtual DbSet<TbLocation> TbLocations { get; set; }
        public virtual DbSet<TbMonitorAssetNo> TbMonitorAssetNos { get; set; }
        public virtual DbSet<TbMonitorList> TbMonitorLists { get; set; }
        public virtual DbSet<TbMsSoftwareList> TbMsSoftwareLists { get; set; }
        public virtual DbSet<TbTypesofJob> TbTypesofJobs { get; set; }
        public virtual DbSet<TbUser> TbUsers { get; set; }
        public virtual DbSet<Workflow> Workflows { get; set; }
        public virtual DbSet<DeviceAndTypesOfReport> DeviceAndTypesOfReports { get; set; }
        public virtual DbSet<DuplicateCheck> DuplicateChecks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=10.0.0.51;user=ndtuser;password=NDTuser@1234;database=ndt_db", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.6.1-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");

            modelBuilder.Entity<EfmigrationsHistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__EFMigrationsHistory");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasKey(e => e.PersistenceId)
                    .HasName("PRIMARY");

                entity.ToTable("Event");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.EventId, "IX_Event_EventId")
                    .IsUnique();

                entity.HasIndex(e => new { e.EventName, e.EventKey }, "IX_Event_EventName_EventKey");

                entity.HasIndex(e => e.EventTime, "IX_Event_EventTime");

                entity.HasIndex(e => e.IsProcessed, "IX_Event_IsProcessed");

                entity.Property(e => e.PersistenceId).HasColumnType("bigint(20)");

                entity.Property(e => e.EventKey).HasMaxLength(200);

                entity.Property(e => e.EventName).HasMaxLength(200);

                entity.Property(e => e.EventTime).HasMaxLength(6);
            });

            modelBuilder.Entity<ExecutionError>(entity =>
            {
                entity.HasKey(e => e.PersistenceId)
                    .HasName("PRIMARY");

                entity.ToTable("ExecutionError");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.PersistenceId).HasColumnType("bigint(20)");

                entity.Property(e => e.ErrorTime).HasMaxLength(6);

                entity.Property(e => e.ExecutionPointerId).HasMaxLength(100);

                entity.Property(e => e.WorkflowId).HasMaxLength(100);
            });

            modelBuilder.Entity<ExecutionPointer>(entity =>
            {
                entity.HasKey(e => e.PersistenceId)
                    .HasName("PRIMARY");

                entity.ToTable("ExecutionPointer");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.WorkflowId, "IX_ExecutionPointer_WorkflowId");

                entity.Property(e => e.PersistenceId).HasColumnType("bigint(20)");

                entity.Property(e => e.EndTime).HasMaxLength(6);

                entity.Property(e => e.EventKey).HasMaxLength(100);

                entity.Property(e => e.EventName).HasMaxLength(100);

                entity.Property(e => e.Id).HasMaxLength(50);

                entity.Property(e => e.PredecessorId).HasMaxLength(100);

                entity.Property(e => e.RetryCount).HasColumnType("int(11)");

                entity.Property(e => e.SleepUntil).HasMaxLength(6);

                entity.Property(e => e.StartTime).HasMaxLength(6);

                entity.Property(e => e.Status).HasColumnType("int(11)");

                entity.Property(e => e.StepId).HasColumnType("int(11)");

                entity.Property(e => e.StepName).HasMaxLength(100);

                entity.Property(e => e.WorkflowId).HasColumnType("bigint(20)");

                entity.HasOne(d => d.Workflow)
                    .WithMany(p => p.ExecutionPointers)
                    .HasForeignKey(d => d.WorkflowId);
            });

            modelBuilder.Entity<ExtensionAttribute>(entity =>
            {
                entity.HasKey(e => e.PersistenceId)
                    .HasName("PRIMARY");

                entity.ToTable("ExtensionAttribute");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.ExecutionPointerId, "IX_ExtensionAttribute_ExecutionPointerId");

                entity.Property(e => e.PersistenceId).HasColumnType("bigint(20)");

                entity.Property(e => e.AttributeKey).HasMaxLength(100);

                entity.Property(e => e.ExecutionPointerId).HasColumnType("bigint(20)");

                entity.HasOne(d => d.ExecutionPointer)
                    .WithMany(p => p.ExtensionAttributes)
                    .HasForeignKey(d => d.ExecutionPointerId);
            });

            modelBuilder.Entity<MailreportlogTbCollectionsYearMonth>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mailreportlog_tb_collectionsYearMonth");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Datetimest)
                    .HasColumnType("datetime")
                    .HasColumnName("datetimest");

                entity.Property(e => e.DeviceId)
                    .HasColumnType("int(11)")
                    .HasColumnName("DeviceID");

                entity.Property(e => e.KeyFailed)
                    .HasMaxLength(100)
                    .HasColumnName("keyFailed");

                entity.Property(e => e.KeySuccess)
                    .HasMaxLength(100)
                    .HasColumnName("keySuccess");

                entity.Property(e => e.KeyWarning)
                    .HasMaxLength(100)
                    .HasColumnName("keyWarning");

                entity.Property(e => e.LogStatus)
                    .HasMaxLength(2)
                    .HasColumnName("logStatus");

                entity.Property(e => e.MailBody)
                    .HasColumnType("mediumtext")
                    .HasColumnName("mailBody");

                entity.Property(e => e.MailLogId)
                    .HasColumnType("int(11)")
                    .HasColumnName("mailLogID");

                entity.Property(e => e.Mailid)
                    .HasMaxLength(18)
                    .HasColumnName("mailid");

                entity.Property(e => e.Monthly).HasColumnName("monthly");

                entity.Property(e => e.ReportId)
                    .HasColumnType("int(11)")
                    .HasColumnName("ReportID");

                entity.Property(e => e.TypesofJobId)
                    .HasColumnType("int(11)")
                    .HasColumnName("TypesofJobID");

                entity.Property(e => e.Yearly).HasColumnName("yearly");
            });

            modelBuilder.Entity<ScheduledCommand>(entity =>
            {
                entity.HasKey(e => e.PersistenceId)
                    .HasName("PRIMARY");

                entity.ToTable("ScheduledCommand");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => new { e.CommandName, e.Data }, "IX_ScheduledCommand_CommandName_Data")
                    .IsUnique();

                entity.HasIndex(e => e.ExecuteTime, "IX_ScheduledCommand_ExecuteTime");

                entity.Property(e => e.PersistenceId).HasColumnType("bigint(20)");

                entity.Property(e => e.CommandName).HasMaxLength(200);

                entity.Property(e => e.Data).HasMaxLength(500);

                entity.Property(e => e.ExecuteTime).HasColumnType("bigint(20)");
            });

            modelBuilder.Entity<Subscription>(entity =>
            {
                entity.HasKey(e => e.PersistenceId)
                    .HasName("PRIMARY");

                entity.ToTable("Subscription");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.EventKey, "IX_Subscription_EventKey");

                entity.HasIndex(e => e.EventName, "IX_Subscription_EventName");

                entity.HasIndex(e => e.SubscriptionId, "IX_Subscription_SubscriptionId")
                    .IsUnique();

                entity.Property(e => e.PersistenceId).HasColumnType("bigint(20)");

                entity.Property(e => e.EventKey).HasMaxLength(200);

                entity.Property(e => e.EventName).HasMaxLength(200);

                entity.Property(e => e.ExecutionPointerId).HasMaxLength(200);

                entity.Property(e => e.ExternalToken).HasMaxLength(200);

                entity.Property(e => e.ExternalTokenExpiry).HasMaxLength(6);

                entity.Property(e => e.ExternalWorkerId).HasMaxLength(200);

                entity.Property(e => e.StepId).HasColumnType("int(11)");

                entity.Property(e => e.SubscribeAsOf)
                    .HasMaxLength(6)
                    .HasDefaultValueSql("'0001-01-01 00:00:00.000000'");

                entity.Property(e => e.SubscriptionId)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsFixedLength()
                    .UseCollation("ascii_general_ci")
                    .HasCharSet("ascii");

                entity.Property(e => e.WorkflowId).HasMaxLength(200);
            });

            modelBuilder.Entity<TbAntiVirusinfo>(entity =>
            {
                entity.HasKey(e => e.IdAntiVirusinfo)
                    .HasName("PRIMARY");

                entity.ToTable("tbAntiVirusinfo");

                entity.HasIndex(e => e.IdAntiVirusinfo, "idAntiVirusinfo_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.ComputerName, "idcomputerList_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdAntiVirusinfo)
                    .HasColumnType("int(11)")
                    .HasColumnName("idAntiVirusinfo");

                entity.Property(e => e.ComputerName)
                    .IsRequired()
                    .HasMaxLength(18)
                    .IsFixedLength()
                    .UseCollation("utf8mb4_general_ci")
                    .HasCharSet("utf8mb4");

                entity.Property(e => e.LastConnectedTime).HasColumnType("datetime");

                entity.Property(e => e.LatestVirusDefsDate).HasColumnType("datetime");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(60)
                    .IsFixedLength()
                    .UseCollation("utf8mb4_general_ci")
                    .HasCharSet("utf8mb4");

                entity.Property(e => e.ProductVersion)
                    .HasMaxLength(60)
                    .IsFixedLength()
                    .UseCollation("utf8mb4_general_ci")
                    .HasCharSet("utf8mb4");
            });

            modelBuilder.Entity<TbComputerAssetNo>(entity =>
            {
                entity.HasKey(e => e.IdComputerAssetNo)
                    .HasName("PRIMARY");

                entity.ToTable("tbComputerAssetNo");

                entity.HasIndex(e => e.ComputerName, "ComputerName_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdComputerAssetNo, "idtbComputerAssetNo_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdComputerAssetNo)
                    .HasColumnType("int(11)")
                    .HasColumnName("idComputerAssetNo");

                entity.Property(e => e.AssetNo)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsFixedLength()
                    .UseCollation("utf8mb4_general_ci")
                    .HasCharSet("utf8mb4");

                entity.Property(e => e.ComputerName)
                    .IsRequired()
                    .HasMaxLength(18)
                    .IsFixedLength()
                    .UseCollation("utf8mb4_general_ci")
                    .HasCharSet("utf8mb4");
            });

            modelBuilder.Entity<TbComputerList>(entity =>
            {
                entity.HasKey(e => e.IdcomputerList)
                    .HasName("PRIMARY");

                entity.ToTable("tbComputerList");

                entity.HasIndex(e => e.ComputerName, "ComputerName_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdcomputerList, "idcomputerList_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdcomputerList)
                    .HasColumnType("int(11)")
                    .HasColumnName("idcomputerList");

                entity.Property(e => e.AssetNo).HasColumnType("int(11)");

                entity.Property(e => e.ComManufacturer)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("'N/A'")
                    .IsFixedLength()
                    .UseCollation("utf8mb4_general_ci")
                    .HasCharSet("utf8mb4");

                entity.Property(e => e.ComModel)
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'N/A'")
                    .IsFixedLength()
                    .UseCollation("utf8mb4_general_ci")
                    .HasCharSet("utf8mb4");

                entity.Property(e => e.ComSerialNo)
                    .HasMaxLength(40)
                    .HasDefaultValueSql("'N/A'")
                    .IsFixedLength()
                    .UseCollation("utf8mb4_general_ci")
                    .HasCharSet("utf8mb4");

                entity.Property(e => e.ComputerName)
                    .HasMaxLength(18)
                    .IsFixedLength();

                entity.Property(e => e.CpuModel)
                    .HasMaxLength(50)
                    .IsFixedLength()
                    .UseCollation("utf8mb4_general_ci")
                    .HasCharSet("utf8mb4");

                entity.Property(e => e.DataUpdate).HasColumnType("datetime");

                entity.Property(e => e.Domain)
                    .HasMaxLength(20)
                    .IsFixedLength()
                    .UseCollation("utf8mb4_general_ci")
                    .HasCharSet("utf8mb4");

                entity.Property(e => e.Ipadds)
                    .HasMaxLength(20)
                    .HasColumnName("IPAdds")
                    .IsFixedLength()
                    .UseCollation("utf8mb4_general_ci")
                    .HasCharSet("utf8mb4");

                entity.Property(e => e.LocationId)
                    .HasColumnType("int(11)")
                    .HasColumnName("LocationID");

                entity.Property(e => e.MacAdds)
                    .HasMaxLength(25)
                    .IsFixedLength()
                    .UseCollation("utf8mb4_general_ci")
                    .HasCharSet("utf8mb4");

                entity.Property(e => e.MonitorId)
                    .HasColumnType("int(11)")
                    .HasColumnName("MonitorID");

                entity.Property(e => e.Nictype)
                    .HasMaxLength(10)
                    .HasColumnName("NICType")
                    .IsFixedLength()
                    .UseCollation("utf8mb4_general_ci")
                    .HasCharSet("utf8mb4");

                entity.Property(e => e.Os)
                    .HasMaxLength(15)
                    .HasColumnName("OS")
                    .IsFixedLength()
                    .UseCollation("utf8mb4_general_ci")
                    .HasCharSet("utf8mb4");

                entity.Property(e => e.Ostype)
                    .HasMaxLength(10)
                    .HasColumnName("OSType")
                    .IsFixedLength()
                    .UseCollation("utf8mb4_general_ci")
                    .HasCharSet("utf8mb4");

                entity.Property(e => e.Ramsize)
                    .HasColumnType("int(11)")
                    .HasColumnName("RAMSize");

                entity.Property(e => e.Status).HasColumnType("tinyint(2)");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("UserID");
            });

            modelBuilder.Entity<TbConfigDeviceOfReport>(entity =>
            {
                entity.HasKey(e => e.DeviceId)
                    .HasName("PRIMARY");

                entity.ToTable("tbConfigDeviceOfReport");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.DeviceId, "DeviceID_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.DeviceId)
                    .HasColumnType("int(11)")
                    .HasColumnName("DeviceID");

                entity.Property(e => e.DeviceName)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.KeyDevice)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.KeyFrom).HasColumnType("tinyint(2)");

                entity.Property(e => e.ReportId)
                    .HasColumnType("int(11)")
                    .HasColumnName("ReportID");

                entity.Property(e => e.TypeKeyForm)
                    .HasColumnType("tinyint(2)")
                    .HasColumnName("typeKeyForm");
            });

            modelBuilder.Entity<TbConfigMailReport>(entity =>
            {
                entity.HasKey(e => e.MailReportId)
                    .HasName("PRIMARY");

                entity.ToTable("tbConfigMailReport");

                entity.HasIndex(e => e.MailReportId, "MailReportID_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.MailReportId).HasColumnType("int(11)");

                entity.Property(e => e.DeviceKeyFrom)
                    .HasColumnType("tinyint(2)")
                    .HasColumnName("deviceKeyFrom");

                entity.Property(e => e.KeyFailed).HasMaxLength(100);

                entity.Property(e => e.KeySuccess).HasMaxLength(100);

                entity.Property(e => e.KeyWarning).HasMaxLength(100);

                entity.Property(e => e.KeyWordFrom).HasColumnType("tinyint(2)");

                entity.Property(e => e.MailAccount)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("mailAccount");

                entity.Property(e => e.MailBody)
                    .HasMaxLength(255)
                    .HasColumnName("mailBody");

                entity.Property(e => e.MailSubject)
                    .HasMaxLength(255)
                    .HasColumnName("mailSubject");

                entity.Property(e => e.ReportName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TbDeviceMatchType>(entity =>
            {
                entity.HasKey(e => e.DeviceMatchTypeId)
                    .HasName("PRIMARY");

                entity.ToTable("tbDeviceMatchType");

                entity.HasIndex(e => e.DeviceMatchTypeId, "DeviceMatchTypeID_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.DeviceMatchTypeId)
                    .HasColumnType("int(11)")
                    .HasColumnName("DeviceMatchTypeID");

                entity.Property(e => e.DeviceId)
                    .HasColumnType("int(11)")
                    .HasColumnName("DeviceID");

                entity.Property(e => e.TypekeyForm).HasColumnType("tinyint(2)");

                entity.Property(e => e.TypesofJobId)
                    .HasColumnType("int(11)")
                    .HasColumnName("TypesofJobID");
            });

            modelBuilder.Entity<TbLocation>(entity =>
            {
                entity.HasKey(e => e.IdLocation)
                    .HasName("PRIMARY");

                entity.ToTable("tbLocation");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.IdLocation, "idLocation_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdLocation)
                    .HasColumnType("int(11)")
                    .HasColumnName("idLocation");

                entity.Property(e => e.LocationName)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<TbMonitorAssetNo>(entity =>
            {
                entity.HasKey(e => e.IdMonitorAssetNo)
                    .HasName("PRIMARY");

                entity.ToTable("tbMonitorAssetNo");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.MonitorSerialNo, "MonitorSerialNo_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdMonitorAssetNo, "idMonitorAssetNo_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdMonitorAssetNo)
                    .HasColumnType("int(11)")
                    .HasColumnName("idMonitorAssetNo");

                entity.Property(e => e.MonitorAsset)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsFixedLength();

                entity.Property(e => e.MonitorSerialNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TbMonitorList>(entity =>
            {
                entity.HasKey(e => e.IdMonitorList)
                    .HasName("PRIMARY");

                entity.ToTable("tbMonitorList");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.MonitorSerialNo, "MonitorSerialNo_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdMonitorList, "idMonitorList_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdMonitorList)
                    .HasColumnType("int(11)")
                    .HasColumnName("idMonitorList");

                entity.Property(e => e.MonitorAsset).HasColumnType("int(11)");

                entity.Property(e => e.MonitorManufacturer)
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.MonitorModel)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.MonitorSerialNo)
                    .HasMaxLength(50)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TbMsSoftwareList>(entity =>
            {
                entity.HasKey(e => e.IdMsSoftwareList)
                    .HasName("PRIMARY");

                entity.ToTable("tbMsSoftwareList");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.IdMsSoftwareList, "idMsSoftwareList_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdMsSoftwareList)
                    .HasColumnType("int(11)")
                    .HasColumnName("idMsSoftwareList");

                entity.Property(e => e.ComputerName)
                    .IsRequired()
                    .HasMaxLength(18)
                    .IsFixedLength();

                entity.Property(e => e.LastInsertData)
                    .HasColumnType("datetime")
                    .HasColumnName("lastInsertData");

                entity.Property(e => e.MsSoftwareDateCreate).HasColumnType("datetime");

                entity.Property(e => e.ProductId)
                    .HasMaxLength(45)
                    .HasColumnName("ProductID")
                    .HasDefaultValueSql("'N/A'")
                    .IsFixedLength();

                entity.Property(e => e.ProductKey)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'N/A'")
                    .IsFixedLength();

                entity.Property(e => e.ProductName)
                    .HasMaxLength(60)
                    .HasDefaultValueSql("'N/A'")
                    .IsFixedLength();
            });

            modelBuilder.Entity<TbTypesofJob>(entity =>
            {
                entity.HasKey(e => e.TypesofJobId)
                    .HasName("PRIMARY");

                entity.ToTable("tbTypesofJob");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.TypesofJobId, "TypesofJobID_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.TypesofJobId)
                    .HasColumnType("int(11)")
                    .HasColumnName("TypesofJobID");

                entity.Property(e => e.DeviceId)
                    .HasColumnType("int(11)")
                    .HasColumnName("DeviceID");

                entity.Property(e => e.KeyForm)
                    .HasColumnType("tinyint(2)")
                    .HasColumnName("keyForm");

                entity.Property(e => e.KeyTypes)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("keyTypes");

                entity.Property(e => e.ReportId)
                    .HasColumnType("int(11)")
                    .HasColumnName("ReportID");

                entity.Property(e => e.TypesofJobName)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<TbUser>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PRIMARY");

                entity.ToTable("tbUser");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.UserLogin, "UserLogin_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdUser, "idUser_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdUser)
                    .HasColumnType("int(11)")
                    .HasColumnName("idUser");

                entity.Property(e => e.UserLastname)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.UserLogin)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Workflow>(entity =>
            {
                entity.HasKey(e => e.PersistenceId)
                    .HasName("PRIMARY");

                entity.ToTable("Workflow");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.InstanceId, "IX_Workflow_InstanceId")
                    .IsUnique();

                entity.HasIndex(e => e.NextExecution, "IX_Workflow_NextExecution");

                entity.Property(e => e.PersistenceId).HasColumnType("bigint(20)");

                entity.Property(e => e.CompleteTime).HasMaxLength(6);

                entity.Property(e => e.CreateTime).HasMaxLength(6);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.InstanceId)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsFixedLength()
                    .UseCollation("ascii_general_ci")
                    .HasCharSet("ascii");

                entity.Property(e => e.NextExecution).HasColumnType("bigint(20)");

                entity.Property(e => e.Reference).HasMaxLength(200);

                entity.Property(e => e.Status).HasColumnType("int(11)");

                entity.Property(e => e.Version).HasColumnType("int(11)");

                entity.Property(e => e.WorkflowDefinitionId).HasMaxLength(200);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
