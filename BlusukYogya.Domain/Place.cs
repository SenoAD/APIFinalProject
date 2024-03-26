using System;
using System.Collections.Generic;

namespace BlusukYogya.Domain;

public partial class Place
{
    public int PlaceId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string Location { get; set; } = null!;

    public decimal Rating { get; set; }

    public int CategoryType { get; set; }

    public decimal? AveragePrice { get; set; }

    public virtual Category CategoryTypeNavigation { get; set; } = null!;

    public virtual ICollection<PlaceReview> PlaceReviews { get; set; } = new List<PlaceReview>();

    public virtual ICollection<PlanItem> PlanItems { get; set; } = new List<PlanItem>();

    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
