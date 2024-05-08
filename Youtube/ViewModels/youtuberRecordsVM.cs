using Youtube.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Youtube.web.ViewModels
{
    public class youtuberRecordsVM
    {
        public YoutuberRecords YoutuberRecords { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? YoutuberList { get; set; }
    }
}
