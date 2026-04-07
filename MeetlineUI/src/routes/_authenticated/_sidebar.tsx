import { createFileRoute, Outlet, useLocation } from '@tanstack/react-router'
import {
  SidebarInset,
  SidebarProvider,
  SidebarTrigger,
} from '#/components/ui/sidebar.tsx'
import { MainSidebar } from '#/components/sidebar/MainSidebar.tsx'
import { useMemo, useState } from 'react'
import { useIsMobile } from '#/hooks/use-mobile.ts'
import { MainHeader } from '#/components/header/MainHeader.tsx'

export const Route = createFileRoute('/_authenticated/_sidebar')({
  component: RouteComponent,
})

function RouteComponent() {
  const { auth, user } = Route.useRouteContext()

  const { href } = useLocation()

  const [isSidebarOpen, setIsSidebarOpen] = useState<boolean>(false)

  const sidebarUser = useMemo(() => {
    const u = user?.user

    if (!u) return null

    return {
      emailAddress: u.emailAddresses[0]?.emailAddress ?? null,
      imageUrl: u.imageUrl,
      fullName: u.fullName,
      username: u.username,
      signOut: () => auth.signOut(),
    }
  }, [user])

  const isMobile = useIsMobile()

  return (
    <SidebarProvider
      open={isMobile && isSidebarOpen}
      onOpenChange={setIsSidebarOpen}
    >

      <MainSidebar user={sidebarUser} currentPath={href} />
      <SidebarInset>
        <MainHeader />
        <Outlet />
      </SidebarInset>
    </SidebarProvider>
  )
}
