using AElf.Playground.MongoDB;
using AElf.Playground.Samples;
using Xunit;

namespace AElf.Playground.MongoDb.Applications;

[Collection(PlaygroundTestConsts.CollectionDefinitionName)]
public class MongoDBSampleAppServiceTests : SampleAppServiceTests<PlaygroundMongoDbTestModule>
{

}
