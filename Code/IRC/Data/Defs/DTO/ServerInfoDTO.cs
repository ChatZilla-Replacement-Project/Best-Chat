// Ignore Spelling: Ssl

namespace BestChat.IRC.Data.Defs.DTO
{
	public record ServerInfoDTO(
		string Domain,
		ushort[] Ports,
		ushort[] SslPorts,
		bool IsEnabled = true);
}