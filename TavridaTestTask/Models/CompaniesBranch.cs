using System;
using System.Collections.Generic;

namespace TavridaTestTask.Models;

public partial class CompaniesBranch
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int CompanyId { get; set; }

    public virtual Company Company { get; set; } = null!;
}
