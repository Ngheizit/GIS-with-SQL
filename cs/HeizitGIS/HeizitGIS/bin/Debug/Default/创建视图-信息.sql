CREATE VIEW ViewMsgs
AS
SELECT     Msgs.[Object-ID], FromUser.[Object-ID] AS FromID, FromUser.Username AS FromName, ToUser.[Object-ID] AS ToUser, ToUser.Username AS ToName, Msgs.Msg, 
                      Msgs.SendTime, Msgs.IsRead
FROM         Users AS FromUser INNER JOIN
                      Msgs ON FromUser.[Object-ID] = Msgs.FromID INNER JOIN
                      Users AS ToUser ON Msgs.ToID = ToUser.[Object-ID]







