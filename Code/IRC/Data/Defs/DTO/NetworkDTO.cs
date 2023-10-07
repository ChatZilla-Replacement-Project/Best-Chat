// Ignore Spelling: Defs DTO

namespace BestChat.IRC.Data.Defs.DTO
{
	public record NetworkDTO(
		string Name,
		ServerInfoDTO[] Servers,
		System.Uri? Homepage = null,
		NickServOpts? NickServ = null,
		ChanServOpts? ChanServ = null,
		bool? HasAlis = null,
		bool? HasQ = null,
		bool AutoConnect = false,
		bool Hidden = false,
		bool UseSSL = true) : IDataDefBasic<NetworkDTO>;
}