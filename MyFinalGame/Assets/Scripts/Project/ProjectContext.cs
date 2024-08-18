
public class ProjectContext 
{
    private static ProjectContext instance;

    public static ProjectContext Instance
    {
        get
        {
            if (instance == null)
                instance = new ProjectContext();
            return instance;
        }
    }
    private ProjectContext()
    {
    }

    public void Init() { }
  
}


