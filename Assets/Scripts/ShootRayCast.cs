using System.Collections;
using UnityEngine;

public class ShootRayCast : MonoBehaviour
{
    public Color rayCastColor;
    private bool canShoot = true;
    void Update()
    {
        if(GameManager.Instance.gamepaused) return;
        shoot();
        Debug.DrawRay(transform.position, transform.forward * 3, rayCastColor);
    }
    private IEnumerator TimerOfDelay()
    {
        canShoot = false;
        yield return new WaitForSeconds(0.2f);
        canShoot = true;
    }

    public void shoot(){
         if (Input.GetKey(KeyCode.Mouse0) && canShoot)
        {
            StartCoroutine(TimerOfDelay());
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit , 50)){
                Debug.Log(hit.transform.name);
                if (hit.transform.CompareTag("Portal") || hit.transform.CompareTag("Ground") || hit.transform.CompareTag("Player"))
                {
            
                }
                else{
                    Destroy(hit.transform.gameObject);
                }
                // hit.transform.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0f,1f), Random.Range(0f,1f), Random.Range(0f,1f), 1);
            }
        }
    }
}
