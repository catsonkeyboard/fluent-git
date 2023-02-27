using CommunityToolkit.Mvvm.Messaging.Messages;
using FluentGit.Infrastructure.MVVM;

namespace FluentGit.Infrastructure.Message
{
    public class CloneCompleteMessage : ValueChangedMessage<BaseViewModel>
    {
        public CloneCompleteMessage(BaseViewModel value) : base(value)
        {

        }
    }
}
