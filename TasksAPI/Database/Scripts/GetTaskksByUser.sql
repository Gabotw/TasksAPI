CREATE OR ALTER PROCEDURE GetTasksByUser
    @UserId INT
    AS
BEGIN
    SET NOCOUNT ON;

SELECT
    t.TaskkId,
    t.Title,
    t.Description,
    t.IsCompleted,
    t.UserId,
    t.CreatedAt AS CreatedDate,
    t.UpdatedAt AS UpdatedDate
FROM
    Taskks t
WHERE
    t.UserId = @UserId
ORDER BY
    t.TaskkId;
END