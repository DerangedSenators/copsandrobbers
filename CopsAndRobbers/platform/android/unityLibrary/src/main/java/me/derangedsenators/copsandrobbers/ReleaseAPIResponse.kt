package me.derangedsenators.copsandrobbers

data class ReleaseAPIResponse(val tag_name: String,val name:String, val assets: List<ReleaseAssets>,val body:String)

data class ReleaseAssets(val name:String, val content_type:String,val size: Long, val browser_download_url: String)