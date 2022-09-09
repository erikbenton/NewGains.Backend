using Microsoft.EntityFrameworkCore;
using NewGains.Core.Entities;
using NewGains.Core.Enums;

namespace NewGains.DataAccess.Contexts;

public class NewGainsDbContext : DbContext
{
	public NewGainsDbContext(DbContextOptions<NewGainsDbContext> options)
		: base(options)
	{

	}

	public DbSet<Exercise> Exercises => Set<Exercise>();

    public DbSet<Instruction> Instructions => Set<Instruction>();

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		SeedData(modelBuilder);
	}

	public static void SeedData(ModelBuilder modelBuilder)
	{
		var benchPress = new Exercise()
		{
			Id = 1,
			Name = "Bench Press",
			BodyPart = BodyPart.Chest,
			Category = Category.Barbell
		};

		var pullUp = new Exercise()
		{
			Id = 2,
			Name = "Pull Up",
			BodyPart = BodyPart.Back,
			Category = Category.WeightedBodyweight
		};

		var squat = new Exercise()
		{
			Id = 3,
			Name = "Squat",
			BodyPart = BodyPart.Legs,
			Category = Category.Barbell
		};

		var overHeadPress = new Exercise()
		{
			Id = 4,
			Name = "Over Head Press",
			BodyPart = BodyPart.Shoulders,
			Category = Category.Barbell
		};

		var bicepCurls = new Exercise()
		{
			Id = 5,
			Name = "Curls",
			BodyPart = BodyPart.Arms,
			Category = Category.Dumbbell,
		};

		var outdoorRunning = new Exercise()
		{
			Id = 6,
			Name = "Outdoor Running",
			BodyPart = BodyPart.Legs,
			Category = Category.Cardio
		};

		var exercises = new List<Exercise>()
		{
			benchPress, pullUp, squat, overHeadPress, bicepCurls, outdoorRunning
		};

		modelBuilder.Entity<Exercise>().HasData(exercises);
    }
}
