using Api.Models.parameters;
using Microsoft.EntityFrameworkCore;
using Api.Models.parameters.Expenses;
using Api.Models.parameters.Expenses.Servicess;
using Api.Models.parameters.Expenses.Services;
using Api.Models.parameters.Expenses.Special;
using API.Models.parameters.Expenses.Fixed;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.Sqlite;

namespace API.Models;

public class Context : DbContext
{

    public Context()
    {
    }

    public Context(DbContextOptions<Context> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
    }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }


    private void OnModelCreatingPartial(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OtherServiceNonTeachingStaff>()
            .HasBaseType<ServiceExpenseModel>();
        modelBuilder.Entity<OtherServiceTeachingStaff>()
            .HasBaseType<ServiceExpenseModel>();
        modelBuilder.Entity<GeneralExpenseModel>()
            .HasBaseType<FixedExpenseModel>();
        modelBuilder.Entity<OtherExpenseModel>()
            .HasBaseType<FixedExpenseModel>();
        modelBuilder.Entity<InvestmentExpenseModel>()
            .HasBaseType<SpecialExpenseModel>();
        modelBuilder.Entity<TransferExpenseModel>()
            .HasBaseType<SpecialExpenseModel>();
        modelBuilder.Entity<TravelExpenseModel>()
            .HasBaseType<ExpenseModel>();
        modelBuilder.Entity<RecurrentCostModel>()
            .HasBaseType<ExpenseModel>();
        modelBuilder.Entity<ServiceExpenseModel>()
            .HasBaseType<ExpenseModel>();
        modelBuilder.Entity<SpecialExpenseModel>()
            .HasBaseType<ExpenseModel>();
        modelBuilder.Entity<FixedExpenseModel>()
            .HasBaseType<ExpenseModel>();

        // modelBuilder.Entity<ExpenseModel>()
        //     .HasDiscriminator<string>("ExpenseType")
        //     .HasValue<TravelExpenseModel>("TravelExpense")
        //     .HasValue<RecurrentCostModel>("RecurrentCost")
        //     .HasValue<OtherExpenseModel>("OtherExpense")
        //     .HasValue<GeneralExpenseModel>("GeneralExpense")
        //     .HasValue<OtherServiceNonTeachingStaff>("OtherServiceNonTeachingStaff")
        //     .HasValue<OtherServiceTeachingStaff>("OtherServiceTeachingStaff")
        //     .HasValue<InvestmentExpenseModel>("InvestmentExpense")
        //     .HasValue<TransferExpenseModel>("TransferExpense");



        modelBuilder.Entity<CohortModel>()
            .HasMany(c => c.Expense)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);


        modelBuilder.Entity<CohortModel>()
            .HasMany(c => c.Registration)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<RegistrationModel>()
            .HasMany(r => r.Subject)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<SubjectModel>()
            .HasOne(s => s.Teacher)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ProgramModel>()
            .HasMany(p => p.Teachers)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<RegistrationModel>()
            .HasOne(r => r.Student)
            .WithMany()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<StudentModel>()
           .HasMany(s => s.Discount)
           .WithOne()
           .HasForeignKey(d => d.Id);


    }

    public DbSet<CohortModel> CohortModel { get; set; } = null!;

    public DbSet<Api.Models.parameters.RegistrationModel> RegistrationModel { get; set; } = default!;

    public DbSet<Api.Models.parameters.StudentModel> StudentModel { get; set; } = default!;

    public DbSet<Api.Models.parameters.SubjectModel> SubjectModel { get; set; } = default!;

    public DbSet<Api.Models.parameters.DiscountModel> DiscountModel { get; set; } = default!;

    public DbSet<Api.Models.parameters.TeacherModel> TeacherModel { get; set; } = default!;

    public DbSet<Api.Models.parameters.ProgramModel> ProgramModel { get; set; } = default!;

    public DbSet<Api.Models.parameters.LeaderModel> LeaderModel { get; set; } = default!;

    public DbSet<Api.Models.parameters.Expenses.ExpenseModel> ExpenseModel { get; set; } = default!;

    public DbSet<Api.Models.parameters.Expenses.TravelExpenseModel> TravelExpenseModel { get; set; } = default!;

    public DbSet<Api.Models.parameters.Expenses.Servicess.ServiceExpenseModel> ServiceExpenseModel { get; set; } = default!;

    public DbSet<Api.Models.parameters.Expenses.Services.OtherServiceNonTeachingStaff> OtherServiceNonTeachingStaff { get; set; } = default!;

    public DbSet<Api.Models.parameters.Expenses.Services.OtherServiceTeachingStaff> OtherServiceTeachingStaff { get; set; } = default!;

    public DbSet<Api.Models.parameters.Expenses.Special.SpecialExpenseModel> SpecialExpenseModel { get; set; } = default!;

    public DbSet<Api.Models.parameters.Expenses.Special.InvestmentExpenseModel> InvestmentExpenseModel { get; set; } = default!;

    public DbSet<Api.Models.parameters.Expenses.Special.TransferExpenseModel> TransferExpenseModel { get; set; } = default!;

    public DbSet<Api.Models.parameters.Expenses.RecurrentCostModel> RecurrentCostModel { get; set; } = default!;

    public DbSet<API.Models.parameters.Expenses.Fixed.FixedExpenseModel> FixedExpenseModel { get; set; } = default!;

    public DbSet<API.Models.parameters.Expenses.Fixed.GeneralExpenseModel> GeneralExpenseModel { get; set; } = default!;

    public DbSet<API.Models.parameters.Expenses.Fixed.OtherExpenseModel> OtherExpenseModel { get; set; } = default!;

    public DbSet<Api.Models.parameters.UserModel> UserModel { get; set; } = default!;
}