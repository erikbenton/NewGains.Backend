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
		SeedData();
	}

	public static void SeedData()
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
	}
}
