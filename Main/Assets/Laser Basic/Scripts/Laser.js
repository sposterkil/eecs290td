//Laser Controller
//This code can be used for private or commercial projects but cannot be sold or redistributed without written permission.
//Copyright Nik W. Kraus / Dark Cube Entertainment LLC. 

    
    
    var StartPoint : Transform;
    var LaserOn = true;    
	var UseUVPan = true;
	
	var EndFlareOffset = 0.0;
	
	var SourceFlare : LensFlare;
	var EndFlare : LensFlare;

	var AddSourceLight = true;
	var AddEndLight = true;

    var LaserColor : Color = Color(1,1,1,.5);
        
    var StartWidth = 0.1;
    var EndWidth = 0.1;
    var LaserDist = 20.0;
	var TexScrollX = -0.1;
	var TexScrollY = 0.1;
    
    private var SectionDetail : float = 2;       
    private var lineRenderer : LineRenderer;
    private var ray = Ray(Vector3(0,0,0), Vector3(0,1,0));	
	private var EndPos : Vector3;
	private var hit: RaycastHit;
	private var SourceLight : GameObject;
	private var EndLight : GameObject;
	private var ViewAngle : float;	
	
	
    @script RequireComponent(LineRenderer)
    
    function Start() {
         var lineRenderer : LineRenderer = GetComponent(LineRenderer);
         if(lineRenderer.material == "none")
         lineRenderer.renderer.material = new Material (Shader.Find("LaserAdditive"));
         
         lineRenderer.castShadows = false;
         lineRenderer.receiveShadows = false;
         
         lineRenderer.SetVertexCount(SectionDetail);
         lineRenderer = GetComponent(LineRenderer);
         
         // Make a lights
        if(AddSourceLight){
		StartPoint.gameObject.AddComponent(Light);
		StartPoint.light.intensity = 1.5;
		StartPoint.light.range = .5;
		}
		
		if(AddEndLight){
			if(EndFlare){
			EndFlare.gameObject.AddComponent(Light);
			EndFlare.light.intensity = 1.5;
			EndFlare.light.range = .5;		
			}
			else{Debug.Log("To use End Light, please assign an End Flare");}
		}
                             
     }//end start
         
    
        /////////////////////////////////////
    function Update() {
    	var CamDistSource = Vector3.Distance(StartPoint.position, Camera.main.transform.position);
    	var CamDistEnd = Vector3.Distance(EndPos, Camera.main.transform.position);
		
		ViewAngle = Vector3.Angle(StartPoint.forward, Camera.main.transform.forward);		 
    	
    	var lineRenderer : LineRenderer = GetComponent(LineRenderer);
    	
    	  	    	
      if(LaserOn){
      	lineRenderer.enabled = true;               
        lineRenderer.SetWidth(StartWidth,EndWidth);
        lineRenderer.material.color = LaserColor;
        
        //Flare Control
        if(SourceFlare){
        SourceFlare.color = LaserColor;
        SourceFlare.transform.position = StartPoint.position;
        
        if(ViewAngle > 155 && CamDistSource < 20 && CamDistSource > 0){
        SourceFlare.brightness = Mathf.Lerp(SourceFlare.brightness,20.0,.001);	
        }
        else{
        SourceFlare.brightness = Mathf.Lerp(SourceFlare.brightness,0.1,.05);
         }        
        }
        
        if(EndFlare){
        EndFlare.color = LaserColor;
        
        if(CamDistEnd > 20){
        EndFlare.brightness = Mathf.Lerp(EndFlare.brightness,0.0,.1);
        }
        else{
        EndFlare.brightness = Mathf.Lerp(EndFlare.brightness,5.0,.1);
         }
        }// end flare        
        
        //Light Control
        if(AddSourceLight)
        StartPoint.light.color = LaserColor;

        if(AddEndLight){
         if(EndFlare){
         EndFlare.light.color = LaserColor;
         }
        }       
        
                        
        /////////////////////Ray Hit
        ray = new Ray(StartPoint.position, StartPoint.forward); 
        if (Physics.Raycast(ray, hit, LaserDist)){	        
	        EndPos = hit.point;	 		    
		    
		    if(EndFlare){
		    EndFlare.enabled = true;
		    
		    if(AddEndLight){
		     if(EndFlare){
		     EndFlare.light.enabled = true;		    
		     }
		    }
		      		    
		    if(EndFlareOffset > 0)
		    EndFlare.transform.position = hit.point + hit.normal * EndFlareOffset;
		    else
		    EndFlare.transform.position = EndPos;
		    }		    
          }
        else{
	        if(EndFlare)
	        EndFlare.enabled = false;	        
	        
	        if(AddEndLight){
		     if(EndFlare){
		     EndFlare.light.enabled = false;
		     }
		    }
		    
           EndPos = ray.GetPoint(LaserDist);	        	        	        	        
        }//end Ray       
        
        
        //Debug.DrawLine (StartPoint.position, EndPos, Color.red);
        
          //Find Distance
	      var dist = Vector3.Distance(StartPoint.position, EndPos);
	      
	      //Line Render Positions
	      lineRenderer.SetPosition(0,StartPoint.position);
	      lineRenderer.SetPosition(1,EndPos);
	                  
    //Texture Scroller
    if(UseUVPan){
    lineRenderer.material.SetTextureScale("_Mask", Vector2(dist/4, .1));
    lineRenderer.material.SetTextureOffset ("_Mask", Vector2(TexScrollX*Time.time, TexScrollY*Time.time));
    }
    
   }
   else{
    lineRenderer.enabled = false;
    
    if(SourceFlare)
    SourceFlare.enabled = false;
    
    if(EndFlare)
	EndFlare.enabled = false;
	        
	if(AddSourceLight)
	StartPoint.light.enabled = false;
	
	if(AddEndLight)
	 if(EndFlare){
	 EndFlare.light.enabled = false;	
	 }	 
   }//end Laser On   
   
  }//end Update