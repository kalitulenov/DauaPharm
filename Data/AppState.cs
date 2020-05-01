using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DauaPharm.Data
{
    public class AppState
    {
        public int BuxFrm { get; set; }
        public int BuxKod { get; set; }
        public int BuxUbl { get; set; }
        public string StrKey { get; set; }

        public event Action OnChange;

        public void SetColour(string colour)
        {
            //  SelectedColour = colour;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
