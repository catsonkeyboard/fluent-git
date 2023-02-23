using CommunityToolkit.Mvvm.Messaging.Messages;
using FluentGit.Infrastructure.ViewBase;

namespace FluentGit.Infrastructure.Message
{
    public class CloneCompleteMessage : ValueChangedMessage<IView>
    {
        public CloneCompleteMessage(IView value) : base(value)
        {

        }
    }
}
