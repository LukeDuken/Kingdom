using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public Collider2D swordCollider;
    Vector2 AttackOffset;
    public float AttackOffsetLeft = -0.16f;
    public float AttackOffsetRight = 0.16f;
    public float AttackOffsetTop = 0.0f;
    public float AttackOffsetDown = -0.16f;

    public enum AttackDirection
    {
        Left,Right,Up,Down
    }

    public AttackDirection attackDirection;
    // Start is called before the first frame update
    private void Start()
    {
        swordCollider = GetComponent<Collider2D>();
        AttackOffset = transform.localPosition;
    }
    public void SwordSwing()
    {
        switch(attackDirection) 
        { 
            case AttackDirection.Left:
                AttackLeft(); 
                break; 
            case AttackDirection.Right:
                AttackRight();
                break;
            case AttackDirection.Up: AttackUp();
                break;
            case AttackDirection.Down: AttackDown();
                break;          
        }
    }
    // Update is called once per frame
    private void AttackRight()
    {
        transform.localPosition = new Vector3(AttackOffsetLeft, AttackOffset.y);
        print("attackRight");
    }

    private void AttackLeft()
    {
        transform.localPosition = new Vector3(AttackOffsetRight, AttackOffset.y);
        print("attackLeft");
    }

    private void AttackUp()
    {
        transform.localPosition = new Vector3(AttackOffset.x, AttackOffsetTop);
        print("attackTop");
    }
    private void AttackDown()
    {
        transform.localPosition = new Vector3(AttackOffset.x, AttackOffsetDown);
        print("attackdown");
    }
    public void StartAttack()
    {
        swordCollider.enabled = true;
        print("startAttack");
    }
    public void StopAttack()
    {
        swordCollider.enabled = false;
        print("stopAttack");
    }
}
