public class Func {
    public delegate void Callback();
    public delegate void Consumer<T>(T t);
    public delegate R Function<T, R>(T t);
}