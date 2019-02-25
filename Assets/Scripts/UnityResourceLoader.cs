using UnityEngine;


public interface IResourceLoader
{
	// test
	T Load<T>(string resourcePath) where T : Object;
}

public class UnityResourceLoader : IResourceLoader
{

	public T Load<T>(string resourcePath) where T : Object
	{
		return Resources.Load<T>(resourcePath);
	}
}
