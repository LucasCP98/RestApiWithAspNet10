namespace RestApiWithAspNet10.Data.Converter.Contract
{
    public interface IParser<O, D>
    {
        D Parse(O orogin);
        List<D> ParseList(List<O> origin);
    }
}
