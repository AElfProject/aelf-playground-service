using System;
using Volo.Abp.EventBus;

namespace AElf.Playground.Eto;

[EventName("AElf.Playground.Job.Request")]
public class JobRequestEto
{
    public Guid Id { get; set; }
    public required string Command { get; set; }
}