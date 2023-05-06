using Microsoft.AspNetCore.Components;

namespace Finaltouch.Modal.App.Shared
{
    /// <summary>
    /// A Blazor Modal Template Component
    /// </summary>
    /// <remarks>
    /// https://stackoverflow.com/questions/59256798/how-to-use-bootstrap-modal-in-blazor-client-app
    /// </remarks>
    public partial class DialogTemplate
    {
        [Parameter]
        public RenderFragment? Body { get; set; }
        [Parameter]
        public RenderFragment? Footer { get; set; }
        [Parameter]
        public string? Title { get; set; }
        [Parameter]
        public bool UseZoom { get; set; }
        [Parameter]
        public bool Scrollable { get; set; }
        public bool Centered { get; set; } = true;
        private string ModalDisplay { get; set; } = "none";
        private string ModalClass { get; set; } = string.Empty;
        private string ModalZoom => UseZoom ? "modal-zoom" : string.Empty;
        private string ModalScroll => Scrollable ? "modal-dialog-scrollable" : string.Empty;
        private string ModalCentered => (Centered && !Scrollable) ? "modal-dialog-centered" : string.Empty;

        private Dictionary<string, object> AriaAttributes
        {
            get
            {
                var attributes = new Dictionary<string, object>();
                if ("block".Equals(ModalDisplay))
                {
                    attributes.Clear();
                    attributes.Add("aria-modal", "true");
                    attributes.Add("role", "dialog");
                }
                else
                {
                    attributes.Clear();
                    attributes.Add("aria-hidden", "true");
                }
                return attributes;
            }
        }

        public async Task Open()
        {
            ModalDisplay = "block";
            await Task.Delay(200);
            ModalClass = "show";
        }

        public async Task Close()
        {
            ModalClass = string.Empty;
            await Task.Delay(200);
            ModalDisplay = "none";
        }

    }
}