using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombiAI : MonoBehaviour
{
    [SerializeField] float zombiKapsam = 4f;
    [SerializeField] float zombiHiz = 5f;
    
    NavMeshAgent navMeshAgent;
    float hedefeKalanMesafe = Mathf.Infinity;
    bool farkedisDurum = false;
    ZombiSaglik saglik;
    Transform hedef;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        saglik = GetComponent<ZombiSaglik>();
        hedef = FindObjectOfType<OyuncuSaglik>().transform;
        enabled = false;
        navMeshAgent.enabled = false;
        StartCoroutine(BugFix());
    }
    void Update()
    {
        if(saglik.yasamDurum())
        {
            enabled = false;
            navMeshAgent.enabled = false;
        }
        hedefeKalanMesafe = Vector3.Distance(hedef.position, transform.position);
        if(farkedisDurum)
        {
            HedefEtkilesim();
        }
        else if(hedefeKalanMesafe <= zombiKapsam)
        {
            farkedisDurum = true;
        }      
    }
    public void HasarAlinca()
    {
        farkedisDurum = true;
    }
    private void HedefEtkilesim()
    {
        HedefBak();
        if(hedefeKalanMesafe >= navMeshAgent.stoppingDistance)
        {
            HedefYakala();
        }
        else if(hedefeKalanMesafe <= navMeshAgent.stoppingDistance)
        {
            HedefSaldır();
        }
    }   
    private void HedefYakala()
    {
        GetComponent<Animator>().SetBool("attack", false);
        GetComponent<Animator>().SetTrigger("move");

        StartCoroutine(BugFix());
        if (navMeshAgent.isActiveAndEnabled)
        {
            navMeshAgent.SetDestination(hedef.position);
        }          
    }
    private void HedefSaldır()
    {
        GetComponent<Animator>().SetBool("attack", true);
    }
    private void HedefBak()
    {
        Vector3 direction = (hedef.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * zombiHiz);
    }
    IEnumerator BugFix()
    {

        yield return new WaitForSeconds(0.2f);
        enabled = true;
        navMeshAgent.enabled = true;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, zombiKapsam);
    }
}
