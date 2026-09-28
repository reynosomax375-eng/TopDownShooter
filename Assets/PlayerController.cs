
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] CharacterController characterController;
    [SerializeField] private float speed;

    [SerializeField] private LayerMask enemyLayer;

    private void Update()
    {


        Vector3 movementVector = Vector3.zero;

        movementVector.x = Input.GetAxis("Horizontal");
        movementVector.y = 0;
        movementVector.z = Input.GetAxis("Vertical");

        characterController.Move(movementVector * Time.deltaTime * speed);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 100f))
        {
            Vector3 position = hitInfo.point;
            position.y = transform.position.y;

            transform.LookAt(position);
        }

        if (Input.GetMouseButtonDown(0))
        {
            LanzarAtaque("Fuego");
        }


        if (Input.GetKeyDown(KeyCode.Q))
        {
            LanzarAtaque("Hielo");
        }


        if (Input.GetKeyDown(KeyCode.E))
        {
            LanzarAtaque("Roca");
        }
    }


    private void LanzarAtaque(string tipoAtaque)
    {
        Ray attackRay = new Ray(transform.position + Vector3.up, transform.forward);
        RaycastHit enemyInfo;

        Debug.DrawRay(
            attackRay.origin,
            attackRay.direction * 10f,
            Color.green,
            10f
        );

        if (Physics.Raycast(
            attackRay.origin,
            attackRay.direction,
            out enemyInfo,
            100f,
            enemyLayer))
        {
            Debug.Log(tipoAtaque + " golpeó a: " + enemyInfo.transform.gameObject.name);
        }
        else
        {
            Debug.Log(tipoAtaque + " no golpeó al enemigo");
        }
    }
}


