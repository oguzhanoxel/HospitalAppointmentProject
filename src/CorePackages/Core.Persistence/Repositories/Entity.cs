namespace Core.Persistence.Repositories;

public abstract class Entity<TId>
{
	public TId Id { get; set; }

	protected Entity()
	{
	}

	protected Entity(TId id) : this()
	{
		Id = id;
	}
}
