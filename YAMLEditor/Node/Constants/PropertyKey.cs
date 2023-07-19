
namespace YAMLEditor.Node.Constants
{
    struct PropertyKey
    {
        public struct FullName
        {
            public const string networks = "infra.networks";
            public const string controlplane = "infra.controlplane";
            public const string worker_pools = "infra.worker_pools";
            public const string control_plane_internal_vip = "infra.controlplane.control_plane_internal_vip";
        }

        public struct LeafName
        {
            public const string gateway_ipv4 = "gateway_ipv4";
        }
        
    }
}
