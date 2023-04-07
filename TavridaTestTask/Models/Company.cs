namespace TavridaTestTask.Models;

public partial class Company
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool BinarySign { get; set; }

    public virtual ICollection<CompaniesBranch> CompaniesBranches { get; } = new List<CompaniesBranch>();
}
