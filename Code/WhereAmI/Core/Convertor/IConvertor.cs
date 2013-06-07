
namespace WhereAmI.Core.Convertor
{
    public interface IConverter<TItemInput, TItemOutput>
    {
        TItemOutput Convert(TItemInput input);
    }
}
