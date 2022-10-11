﻿using System.ComponentModel.DataAnnotations;

namespace NewGains.API.Dtos.Templates;

public record TemplateSetGroupCreateDto
{
    [Required]
    public int ExerciseId { get; init; }
    [StringLength(255)]
    public string? Note { get; init; }

    public IEnumerable<TemplateSetCreateDto>? Sets { get; init; }

    public TemplateSetGroupCreateDto(
        int exerciseId,
        string? note,
        IEnumerable<TemplateSetCreateDto>? sets)
    {
        ExerciseId = exerciseId;
        Note = note;
        Sets = sets;
    }
}