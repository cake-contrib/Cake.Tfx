using Cake.Core.IO;

namespace Cake.Tfx
{
    public interface ITfxArgumentBuilder
    {
        ProcessArgumentBuilder GetArguments();
    }
}