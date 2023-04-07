using System.ComponentModel;

namespace TavridaTestTask.Models.ViewModels
{
    public class CompanyBranchViewModel
    {
        [DisplayName("Филиал")]
        public string CompanyBranchName { get; set; } = string.Empty;
        [DisplayName("Компания Филиала")]
        public string CompanyName { get; set; } = string.Empty;
        [DisplayName("Группа Компании")]
        public bool CompanyGroup { get; set; }
        [DisplayName("Связанные филиалы")]
        public string RelatedBranches { get; set; } = string.Empty;
    }
}
