﻿/***************************************************************************************

	Copyright 2014 Greg Dennis

	   Licensed under the Apache License, Version 2.0 (the "License");
	   you may not use this file except in compliance with the License.
	   You may obtain a copy of the License at

		 http://www.apache.org/licenses/LICENSE-2.0

	   Unless required by applicable law or agreed to in writing, software
	   distributed under the License is distributed on an "AS IS" BASIS,
	   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
	   See the License for the specific language governing permissions and
	   limitations under the License.
 
	File Name:		BoardPreferencesContext.cs
	Namespace:		Manatee.Trello.Internal.Synchronization
	Class Name:		BoardPreferencesContext
	Purpose:		Provides a data context for a boards preferences.

***************************************************************************************/

using System.Collections.Generic;
using Manatee.Trello.Json;

namespace Manatee.Trello.Internal.Synchronization
{
	internal class BoardPreferencesContext : LinkedSynchronizationContext<IJsonBoardPreferences>
	{
		static BoardPreferencesContext()
		{
			_properties = new Dictionary<string, Property<IJsonBoardPreferences>>
				{
					{
						"PermissionLevel", new Property<IJsonBoardPreferences>(d => d.PermissionLevel.ConvertEnum<BoardPermissionLevel>(),
						                                                       (d, o) => d.PermissionLevel = ((BoardPermissionLevel) o).ConvertEnum())
					},
					{
						"Voting", new Property<IJsonBoardPreferences>(d => d.Voting.ConvertEnum<BoardVotingPermission>(),
						                                              (d, o) => d.Voting = ((BoardVotingPermission) o).ConvertEnum())
					},
					{
						"Comments", new Property<IJsonBoardPreferences>(d => d.Comments.ConvertEnum<BoardCommentPermission>(),
						                                                (d, o) => d.Comments = ((BoardCommentPermission) o).ConvertEnum())
					},
					{
						"Invitations", new Property<IJsonBoardPreferences>(d => d.Invitations.ConvertEnum<BoardInvitationPermission>(),
						                                                   (d, o) => d.Invitations = ((BoardInvitationPermission) o).ConvertEnum())
					},
					{"SelfJoin", new Property<IJsonBoardPreferences>(d => d.SelfJoin, (d, o) => d.SelfJoin = (bool?) o)},
					{"CardCovers", new Property<IJsonBoardPreferences>(d => d.CardCovers, (d, o) => d.CardCovers = (bool?) o)},
				};
		}
	}
}