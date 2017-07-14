namespace Test.It
{
    public interface IUseConfiguration<in TConfiguration>
    {
        void SetConfiguration(TConfiguration configuration);
    }
}