using System;
using LogoFX.Client.Mvvm.Model;

namespace BugTracker.Shared.Models
{
    public abstract class AppModel : EditableModel<Guid>
    {
        protected AppModel()
        {
            Id = Guid.NewGuid();
        }
    }
}
