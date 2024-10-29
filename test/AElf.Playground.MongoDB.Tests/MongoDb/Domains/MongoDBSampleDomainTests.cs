using AElf.Playground.Samples;
using Xunit;

namespace AElf.Playground.MongoDB.Domains;

[Collection(PlaygroundTestConsts.CollectionDefinitionName)]
public class MongoDBSampleDomainTests : SampleDomainTests<PlaygroundMongoDbTestModule>
{

}
