public class TranslationBomberdev {
	public Direction direction;
	public int numberOfSteps;
	public Func.Callback callback;

	public TranslationBomberdev(Direction direction, int numberOfSteps, Func.Callback callback) {
		this.direction = direction;
		this.callback = callback;
		this.numberOfSteps = numberOfSteps;
	}
}