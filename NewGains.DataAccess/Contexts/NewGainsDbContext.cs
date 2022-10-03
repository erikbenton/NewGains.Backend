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

	public DbSet<Template> Templates => Set<Template>();

    public DbSet<TemplateSetGroup> TemplateSetGroups => Set<TemplateSetGroup>();

    public DbSet<TemplateSet> TemplateSets => Set<TemplateSet>();

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

        var templateId = 1;
        var templatePush = new Template()
        {
            Id = templateId++,
            Name = "Push"
        };

        var templateSetGroupId = 1;
		var templatePushSetGroup1 = new TemplateSetGroup()
		{
			Id = templateSetGroupId++,
			SetGroupNumber = 1,
            TemplateId = templatePush.Id,
			ExerciseId = benchPress.Id
		};

        var templatePushSetGroup2 = new TemplateSetGroup()
        {
            Id = templateSetGroupId++,
            SetGroupNumber = 2,
            TemplateId = templatePush.Id,
            ExerciseId = pullUp.Id
        };

        var templatePushSetGroup3 = new TemplateSetGroup()
        {
            Id = templateSetGroupId++,
            SetGroupNumber = 3,
            TemplateId = templatePush.Id,
            ExerciseId = overHeadPress.Id
        };

        var templatePushSetGroup4 = new TemplateSetGroup()
        {
            Id = templateSetGroupId++,
            SetGroupNumber = 4,
            TemplateId = templatePush.Id,
            ExerciseId = squat.Id
        };

        var benchSets = new List<TemplateSet>();
        var pullUpSets = new List<TemplateSet>();
        var overHeadPressSets = new List<TemplateSet>();
        var squatSets = new List<TemplateSet>();

        int templateSetId = 1;
        for (int setNumber = 1; setNumber < 4; setNumber++)
        {
            benchSets.Add(
                new TemplateSet()
                {
                    Id = templateSetId++,
                    SetNumber = setNumber,
                    ExerciseId = benchPress.Id,
                    SetGroupId = templatePushSetGroup1.Id
                });

            pullUpSets.Add(
                new TemplateSet()
                {
                    Id = templateSetId++,
                    SetNumber = setNumber,
                    ExerciseId = pullUp.Id,
                    SetGroupId = templatePushSetGroup2.Id
                });

            overHeadPressSets.Add(
                new TemplateSet()
                {
                    Id = templateSetId++,
                    SetNumber = setNumber,
                    ExerciseId = overHeadPress.Id,
                    SetGroupId = templatePushSetGroup3.Id
                });

            squatSets.Add(
                new TemplateSet()
                {
                    Id = templateSetId++,
                    SetNumber = setNumber,
                    ExerciseId = squat.Id,
                    SetGroupId = templatePushSetGroup4.Id
                });
        }

        modelBuilder.Entity<TemplateSetGroup>().HasData(templatePushSetGroup1);
        modelBuilder.Entity<TemplateSetGroup>().HasData(templatePushSetGroup2);
        modelBuilder.Entity<TemplateSetGroup>().HasData(templatePushSetGroup3);
        modelBuilder.Entity<TemplateSetGroup>().HasData(templatePushSetGroup4);
        modelBuilder.Entity<TemplateSet>().HasData(benchSets);
        modelBuilder.Entity<TemplateSet>().HasData(pullUpSets);
        modelBuilder.Entity<TemplateSet>().HasData(overHeadPressSets);
        modelBuilder.Entity<TemplateSet>().HasData(squatSets);
        modelBuilder.Entity<Template>().HasData(templatePush);
    }
}
