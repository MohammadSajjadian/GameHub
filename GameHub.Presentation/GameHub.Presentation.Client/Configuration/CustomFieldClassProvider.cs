using Microsoft.AspNetCore.Components.Forms;

namespace GameHub.Presentation.Client.Configuration
{
    public class CustomFieldClassProvider : FieldCssClassProvider
    {
        public override string GetFieldCssClass(EditContext editContext, in FieldIdentifier fieldIdentifier)
        {
            var isValid = editContext.GetValidationMessages(fieldIdentifier).Any();
            if (editContext.IsModified(fieldIdentifier))
                return isValid ? " is-valid" : "is-invalid";

            return isValid ? "" : "is-invalid";
        }
    }
}
