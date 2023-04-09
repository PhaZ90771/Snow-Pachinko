using UnityEditor;
using UnityEngine;

public class SnowflakeSpawner : MonoBehaviour
{
    public GameObject SnowflakePrefab;
    [Range(1f,5f)]
    public uint SpawnDelay = 1;

    private Vector2 left;
    private Vector2 right;
    private float lastSpawn = 0f;

    private void Awake()
    {
        var xOffset = 0.5f * transform.localScale.x;
        left = new Vector2(transform.position.x - xOffset, transform.position.y);
        right = new Vector2(transform.position.x + xOffset, transform.position.y);

        SpawnSnowflake();
    }

    private void Update()
    {
        if (Time.time - lastSpawn > SpawnDelay)
        {
            SpawnSnowflake();
        }
    }

    private void SpawnSnowflake()
    {
        var posX = Random.Range(left.x, right.x);
        var posY = Random.Range(left.y, right.y);
        var position = new Vector3(posX, posY);
        Instantiate(SnowflakePrefab, position, new Quaternion(), null);
        lastSpawn = Time.time;
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Color gizmoColor = Color.green;
        Handles.color = gizmoColor;
        Gizmos.color = gizmoColor;

        var guiStyle = new GUIStyle();
        guiStyle.alignment = TextAnchor.LowerCenter;
        guiStyle.normal.textColor = gizmoColor;

        var middleY = transform.position.y;
        var topY = middleY + 0.5f * transform.localScale.y;
        var bottomY = middleY - 0.5f * transform.localScale.y;
        var middleX = transform.position.x;
        var leftX = middleX - 0.5f * transform.localScale.x;
        var rightX = middleX + 0.5f * transform.localScale.x;

        var labelPosition = new Vector2(middleX, topY);
        Handles.Label(labelPosition, "Snowflake Spawner", guiStyle);

        var startLine = new Vector2(leftX, middleY);
        var endLine = new Vector2(rightX, middleY);
        Gizmos.DrawLine(startLine, endLine);

        var leftBracketTop = new Vector2(leftX, topY);
        var leftBracketBottom = new Vector2(leftX, bottomY);
        Gizmos.DrawLine(leftBracketTop, leftBracketBottom);

        var rightBracketTop = new Vector2(rightX, topY);
        var rightBracketBottom = new Vector2(rightX, bottomY);
        Gizmos.DrawLine(rightBracketTop, rightBracketBottom);
    }
#endif
}
