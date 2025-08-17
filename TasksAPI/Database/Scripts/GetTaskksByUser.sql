CREATE OR ALTER PROCEDURE GetTasksByUser
    @UserId INT
    AS
BEGIN
    SET NOCOUNT ON;

SELECT
    t.taskk_id,
    t.title,
    t.description,
    t.is_completed,
    t.is_deleted,
    t.user_id,
    t.created_at,
    t.updated_at 
FROM
    Taskks t
WHERE
    t.user_id = @UserId
  AND t.is_deleted = 0
ORDER BY
    t.taskk_id;
END