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
		int exerciseId = 1;
		int instructionId = 1;

		var benchPress = new Exercise()
		{
			Id = exerciseId++,
			Name = "Bench Press",
			BodyPart = BodyPart.Chest,
			Category = Category.Barbell
		};

		var benchPressInstructions = new List<Instruction>()
		{
			new Instruction()
			{
				Id = instructionId++, StepNumber = 1, ExerciseId = benchPress.Id,
				Text = "Lie flat on the bench holding the barbell with a shoulder width pronated grip."
			},
            new Instruction()
            {
                Id = instructionId++, StepNumber = 2, ExerciseId = benchPress.Id,
                Text = @"Retract scapula and have elbows between 45 to 90 degree angle.
						 Try to tuck the shoulders down into their sockets and driven back."
            },
            new Instruction()
            {
                Id = instructionId++, StepNumber = 3, ExerciseId = benchPress.Id,
                Text = "Lift bar from the rack and hold above the chest with arms extended."
            },
            new Instruction()
            {
                Id = instructionId++, StepNumber = 4, ExerciseId = benchPress.Id,
                Text = "Breathe in and lower bar to the middle chest."
            },
            new Instruction()
            {
                Id = instructionId++, StepNumber = 5, ExerciseId = benchPress.Id,
                Text = "After pausing at the bottom, push the bar towards the starting position squeezing the chest."
            },
            new Instruction()
            {
                Id = instructionId++, StepNumber = 6, ExerciseId = benchPress.Id,
                Text = "Repeat for reps"
            },
        };

		var pullUp = new Exercise()
		{
			Id = exerciseId++,
			Name = "Pull Up",
			BodyPart = BodyPart.Back,
			Category = Category.WeightedBodyweight
		};

        var pullupInstructions = new List<Instruction>()
        {
            new Instruction()
            {
                Id = instructionId++, StepNumber = 1, ExerciseId = pullUp.Id,
                Text = "Hold the pull up bar with a neutral grip with arms fully extended."
            },
            new Instruction()
            {
                Id = instructionId++, StepNumber = 2, ExerciseId = pullUp.Id,
                Text = "Retract scapula and pull upward by bringing chest to the bar."
            },
            new Instruction()
            {
                Id = instructionId++, StepNumber = 3, ExerciseId = pullUp.Id,
                Text = "Pause at the top and squeeze the back before lowering slowly to the starting position."
            },
            new Instruction()
            {
                Id = instructionId++, StepNumber = 4, ExerciseId = pullUp.Id,
                Text = "Repeat for reps"
            },
        };

        var squat = new Exercise()
		{
			Id = exerciseId++,
			Name = "Squat",
			BodyPart = BodyPart.Legs,
			Category = Category.Barbell
		};

		var overHeadPress = new Exercise()
		{
			Id = exerciseId++,
			Name = "Over Head Press",
			BodyPart = BodyPart.Shoulders,
			Category = Category.Barbell
		};

		var bicepCurls = new Exercise()
		{
			Id = exerciseId++,
			Name = "Curls",
			BodyPart = BodyPart.Arms,
			Category = Category.Dumbbell,
		};

		var outdoorRunning = new Exercise()
		{
			Id = exerciseId++,
			Name = "Outdoor Running",
			BodyPart = BodyPart.Legs,
			Category = Category.Cardio
		};

		var exercises = new List<Exercise>()
		{
			benchPress, pullUp, squat, overHeadPress, bicepCurls, outdoorRunning
		};

		modelBuilder.Entity<Exercise>().HasData(exercises);
		modelBuilder.Entity<Instruction>().HasData(benchPressInstructions);
        modelBuilder.Entity<Instruction>().HasData(pullupInstructions);
    }
}
