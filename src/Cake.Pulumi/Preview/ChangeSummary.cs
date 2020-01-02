using Newtonsoft.Json;

namespace Cake.Pulumi
{
    public class ChangeSummary
    {
        [JsonProperty("same")]
        public int Same { get; set; }
        [JsonProperty("create")]
        public int Create { get; set; }
        [JsonProperty("update")]
        public int Update { get; set; }
        [JsonProperty("delete")]
        public int Delete { get; set; }
        [JsonProperty("replace")]
        public int Replace { get; set; }
        [JsonProperty("create-replacement")]
        public int CreateReplaced { get; set; }
        [JsonProperty("delete-replaced")]
        public int DeleteReplaced { get; set; }

        public int Changes => Create + Update + Delete + Replace + CreateReplaced + DeleteReplaced;

        public static implicit operator bool(ChangeSummary s) => s.Changes > 0;

        public override string ToString()
        {
            return $"{nameof(Changes)}: {Changes} [{nameof(Same)}: {Same}, {nameof(Create)}: {Create}, {nameof(Update)}: {Update}, {nameof(Delete)}: {Delete}, {nameof(Replace)}: {Replace}, {nameof(CreateReplaced)}: {CreateReplaced}, {nameof(DeleteReplaced)}: {DeleteReplaced}]";
        }
    }
}