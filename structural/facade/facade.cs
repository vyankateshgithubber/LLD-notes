public class DeploymentFacade {
    private VersionControlSystem vcs = new VersionControlSystem();
    private BuidlSystem build = new BuidlSystem();
    private TestingFramework test = new TestingFramwework();
    private DeploymentTarget deploy =  new DeploymentTarget();
    public bool deployApplication(string branch,string serverAddress){
        vcs.pullLatestChanges(branch);
        build.getArtifactPath();
        test.runIntegrationTests();
        deploy.transferArtifact();
    }
}